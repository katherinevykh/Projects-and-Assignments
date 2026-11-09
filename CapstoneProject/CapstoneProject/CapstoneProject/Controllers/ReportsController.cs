using CapstoneProject.Data;
using CapstoneProject.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class ReportsController : Controller
    {
        private readonly CapstoneProjectDbContext _db;

        public ReportsController(CapstoneProjectDbContext db)
        {
            _db = db;
        }
        [Route("Reports/ReportsForm")]
        public IActionResult ReportsForm()
        {
            return View();
        }

		[HttpPost]
		public IActionResult CreateExcelFile([FromBody] ReportDateDTO reportDate)
		{
			DateOnly startDate = DateOnly.Parse(reportDate.start);
			DateOnly endDate = DateOnly.Parse(reportDate.end);
            List<Donation> donationList = _db.Donations
				.Where(d => d.Date >= startDate && d.Date <= endDate)
				.ToList();
            List<Purchasing> purchaseList = _db.Purchases
				.Where(p => p.Date >= startDate && p.Date <= endDate)
				.ToList();
            /*List<TransactionForReport> transactionList = _db.Transactions
				.Where(t => t.Date >= startDate && t.Date <= endDate)
				.Join(_db.TransactionLineItems,
					t => t.TransactionID,
					l => l.TransactionID,
					(t, l) => new {t, l})
				.Join(_db.Items,
					tl => tl.l.ItemID,
					i => i.ItemID,
					(tl, i) => new TransactionForReport
					{
						TransactionID = tl.t.TransactionID,
						UserID = tl.t.UserID,
						Date = tl.t.Date,
						Type = i.ItemSubcategory.Name,
						Quantity = i.Quantity,
                        IsRG = tl.l.IsRG,
                        IsPAL = tl.l.IsPAL
					})
				.ToList();*/
            List<Models.Transaction> transactionList = _db.Transactions.Where(t => t.Date >= startDate && t.Date <= endDate)
                .Include(t=>t.LineItems).ThenInclude(l=>l.Item).ThenInclude(i=>i.ItemSubcategory).ToList();
            //List<Models.Transaction> forRepeatVisitorsList = _db.Transactions
            //    .Where(t => t.Date >= startDate && t.Date <= endDate)
            //    .ToList ();
            List<ResourceRequest> resourceRequestList = _db.ResourceRequests
                .Where(r => r.Date >= startDate && r.Date <= endDate)
                .ToList ();
            byte[] fileContents = CreateExcelFile(donationList, purchaseList, transactionList, resourceRequestList);

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
        }

        private byte[] CreateExcelFile(List<Donation> donationList, List<Purchasing> purchaseList, List<Models.Transaction> transactionList, List<ResourceRequest> resourceRequestList)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    //Creates a workbook. Because of how the xml that builds Excel files is laid out, there are many layers to this code.
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    //The following is all essential to create a sheet in the workbook. The WorksheetPart, Worksheet, Sheet, and SheetData all make up 'layers' of a sheet.
                    WorksheetPart userWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet userWorksheet = new Worksheet();
                    userWorksheetPart.Worksheet = userWorksheet;

					//The Sheets section is an index of the Sheet parts of the file. You only need one of these.
                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet userSheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(userWorksheetPart), SheetId = 1, Name = "DataSummary" };
                    sheets.Append(userSheet);

                    SheetData userSheetData = userWorksheet.AppendChild(new SheetData());

                    //Adding data to the worksheet.
                    Row userHeaderRow = new Row();
                    userHeaderRow.Append(
                        new Cell() { CellValue = new CellValue("Total Visits"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Total Visitors"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Repeat Visitors"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("# Items Rec By Students"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Avg # Items Rec By Students"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("RG Donations Rec By Students"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("PALS Donations Rec By Students"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Monetary Donations"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Donations"), DataType = CellValues.String }
                    );
                    userSheetData.AppendChild(userHeaderRow);

                    Row userDataRow = new Row();
                    userDataRow.Append(
                        new Cell() { CellValue = new CellValue(TotalVisits(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(TotalVisitors(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(RepeatVisitors(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(ItemsRecieved(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(AverageItemsRecieved(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(DonatedByRG(transactionList)), DataType = CellValues.Number },
						new Cell() { CellValue = new CellValue(DonatedByPAL(transactionList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(MoneyDonated(donationList)), DataType = CellValues.Number },
                        new Cell() { CellValue = new CellValue(OtherDonated(donationList)), DataType = CellValues.Number }
                    );
                    userSheetData.AppendChild(userDataRow);

					//Creating another worksheet for a different table.
					WorksheetPart donationWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
					Worksheet donationWorksheet = new Worksheet();
					donationWorksheetPart.Worksheet = donationWorksheet;

					Sheet donationSheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(donationWorksheetPart), SheetId = 2, Name = "DonationData" };
					sheets.Append(donationSheet);

					SheetData donationSheetData = donationWorksheet.AppendChild(new SheetData());

					Row donationHeaderRow = new Row();
					donationHeaderRow.Append(
						new Cell() { CellValue = new CellValue("Donation ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Date"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("First Name"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Middle Name"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Last Name"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Value"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Company"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Type"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Quantity"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Notes"), DataType = CellValues.String }
					);
					donationSheetData.AppendChild(donationHeaderRow);

                    foreach (var donation in donationList)
                    {
						Row donationDataRow = new Row();
						donationDataRow.Append(
						    new Cell() { CellValue = new CellValue(donation.DonationID), DataType = CellValues.Number },
						    new Cell() { CellValue = new CellValue(donation.Date.ToShortDateString()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.FirstName.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.MidName.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.LastName.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.Value), DataType = CellValues.Number },
						    new Cell() { CellValue = new CellValue(donation.Company.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.Type.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(donation.Quantity), DataType = CellValues.Number },
						    new Cell() { CellValue = new CellValue(donation.Notes.Trim()), DataType = CellValues.String }
					    );
                        donationSheetData.AppendChild(donationDataRow);
					}

					WorksheetPart purchaseWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
					Worksheet purchaseWorksheet = new Worksheet();
					purchaseWorksheetPart.Worksheet = purchaseWorksheet;

					Sheet purchaseSheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(purchaseWorksheetPart), SheetId = 3, Name = "PurchaseData" };
					sheets.Append(purchaseSheet);

					SheetData purchaseSheetData = purchaseWorksheet.AppendChild(new SheetData());

					Row purchaseHeaderRow = new Row();
					purchaseHeaderRow.Append(
						new Cell() { CellValue = new CellValue("Purchase ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Shop Transaction ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Store Name"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Date"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Payment Method"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Total Spent"), DataType = CellValues.String }
					);
					purchaseSheetData.AppendChild(purchaseHeaderRow);

                    foreach (var purchase in purchaseList)
                    {
						Row purchaseDataRow = new Row();
						purchaseDataRow.Append(
							new Cell() { CellValue = new CellValue(purchase.PurchaseID), DataType = CellValues.Number },
						    new Cell() { CellValue = new CellValue(purchase.ShopTransactionID.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(purchase.StoreName.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(purchase.Date.ToShortDateString()), DataType = CellValues.Date },
						    new Cell() { CellValue = new CellValue(purchase.PaymentMethod.Trim()), DataType = CellValues.String },
						    new Cell() { CellValue = new CellValue(purchase.TotalSpent), DataType = CellValues.Number }
						);
                        purchaseSheetData.AppendChild(purchaseDataRow);
                    }

					WorksheetPart transactionWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
					Worksheet transactionWorksheet = new Worksheet();
					transactionWorksheetPart.Worksheet = transactionWorksheet;

					Sheet transactionSheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(transactionWorksheetPart), SheetId = 4, Name = "TransactionData" };
					sheets.Append(transactionSheet);

					SheetData transactionSheetData = transactionWorksheet.AppendChild(new SheetData());

					Row transactionHeaderRow = new Row();
					transactionHeaderRow.Append(
						new Cell() { CellValue = new CellValue("Transaction ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("User ID"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Date"), DataType = CellValues.String },
						new Cell() { CellValue = new CellValue("Item Type"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Quantity"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Donated by RG"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Donated by PAL"), DataType = CellValues.String }

                    );
					transactionSheetData.AppendChild(transactionHeaderRow);

					foreach (var transaction in transactionList)
					{
                        foreach (var line in transaction.LineItems)
                        {
                            Row transactionDataRow = new Row();
                            transactionDataRow.Append(
                                new Cell() { CellValue = new CellValue(transaction.TransactionID), DataType = CellValues.Number },
                                new Cell() { CellValue = new CellValue(transaction.UserID), DataType = CellValues.String },
                                new Cell() { CellValue = new CellValue(transaction.Date.ToShortDateString()), DataType = CellValues.String },
                                new Cell() { CellValue = new CellValue(line.Item.ItemSubcategory.Name.Trim()), DataType = CellValues.String },
                                new Cell() { CellValue = new CellValue(line.Quantity), DataType = CellValues.Number },
                                new Cell() { CellValue = new CellValue(line.IsRG), DataType = CellValues.Boolean },
                                new Cell() { CellValue = new CellValue(line.IsPAL), DataType = CellValues.Boolean }
                            );
                            transactionSheetData.AppendChild(transactionDataRow);
                        }
					}

                    WorksheetPart resourceRequestWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet resourceRequestWorksheet = new Worksheet();
                    resourceRequestWorksheetPart.Worksheet = resourceRequestWorksheet;

                    Sheet resourceRequestSheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(resourceRequestWorksheetPart), SheetId = 5, Name = "ResourceRequestData" };
                    sheets.Append(resourceRequestSheet);

                    SheetData resourceRequestSheetData = resourceRequestWorksheet.AppendChild(new SheetData());

                    Row resourceRequestHeaderRow = new Row();
                    resourceRequestHeaderRow.Append(
                        new Cell() { CellValue = new CellValue("Request ID"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("User ID"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Date"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Household Adults"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Household Minors"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Has a Stove"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Has an Oven"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Has a Microwave"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Has a Can Opener"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Has Running Water"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Dietary Restrictions"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Allergies"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Chili Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Chicken Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Tomato Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Cream Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Vegetable Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Soup"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Vegetable Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Chicken Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Shrimp Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Beef Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Pork Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Ramen"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Tuna"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Canned Meat"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Mixed Veggies"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Peas"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Green Beans"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Corn"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Tomatoes"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Carrots"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Canned Vegetables"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Beans"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Dry Beans"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Beef Boxed Meal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Chicken Boxed Meal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Vegetarian Boxed Meal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Boxed Meal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Granola Bars"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Crackers"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Chips"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Other Snacks"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Kids Cereal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Oatmeal"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Breakfast Bars"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Canned Fruit"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Peanut Butter"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Jelly"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Mac N Cheese"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Mashed Potatoes"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Rice"), DataType = CellValues.String },
                        new Cell() { CellValue = new CellValue("Pasta and Sauce"), DataType = CellValues.String }
                    );
                    resourceRequestSheetData.AppendChild(resourceRequestHeaderRow);

                    foreach (var resourceRequest in resourceRequestList)
                    {
                        Row resourceRequestDataRow = new Row();
                        resourceRequestDataRow.Append(
                            new Cell() { CellValue = new CellValue(resourceRequest.RequestID), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(resourceRequest.UserID), DataType = CellValues.String },
                            new Cell() { CellValue = new CellValue(resourceRequest.Date.ToShortDateString()), DataType = CellValues.String },
                            new Cell() { CellValue = new CellValue(resourceRequest.HouseholdAdults), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(resourceRequest.HouseholdUnderage), DataType = CellValues.Number },
                            new Cell() { CellValue = new CellValue(resourceRequest.Stove), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.Oven), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.Microwave), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanOpener), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RunningWater), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.DietaryRestrictions), DataType = CellValues.String },
                            new Cell() { CellValue = new CellValue(resourceRequest.Allergies), DataType = CellValues.String },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupChili), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupChicken), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupTomato), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupCream), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupVegetable), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SoupOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenVegetable), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenChicken), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenShrimp), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenBeef), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenPork), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.RamenOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanMeatTuna), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanMeatOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableMix), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetablePeas), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableGreenBean), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableCorn), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableTomato), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableCarrot), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CanVegetableOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BeanCanned), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BeanDry), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BoxMealBeef), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BoxMealChicken), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BoxMealVegetarian), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.BoxMealOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SnackGranolaBar), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SnackCrackers), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SnackChips), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.SnackOther), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CerealKids), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CerealOatmeal), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.CerealBreakfastBar), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherCannedFruit), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherPeanutButter), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherJelly), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherMacNCheese), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherMashedPotatoe), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherRice), DataType = CellValues.Boolean },
                            new Cell() { CellValue = new CellValue(resourceRequest.OtherPastaAndSauce), DataType = CellValues.Boolean }
                        );
                        resourceRequestSheetData.AppendChild(resourceRequestDataRow);
                    }
                    workbookPart.Workbook.Save();
                }
                return memoryStream.ToArray();
            }
        }

		private int TotalVisits(List<Models.Transaction> transactionList)
		{
			List<int> uniqueList = new List<int>();
			foreach (var transaction in transactionList)
			{
				if (!uniqueList.Contains(transaction.TransactionID))
				{
					uniqueList.Add(transaction.TransactionID);
				}
			}
			return uniqueList.Count;
		}

        private int TotalVisitors(List<Models.Transaction> transactionList)
        {
            List<string> uniqueList = new List<string>();
            foreach (var transaction in transactionList)
            {
                if (!uniqueList.Contains(transaction.UserID))
                {
                    uniqueList.Add(transaction.UserID);
                }
            }
            return uniqueList.Count;
        }

		private int RepeatVisitors(List<Models.Transaction> forRepeatVisitorsList)
        {
            List<string> uniqueList = new List<string>();
			int repeatCount = 0;
            foreach (var transaction in forRepeatVisitorsList)
            {
                if (!uniqueList.Contains(transaction.UserID))
                {
                    uniqueList.Add(transaction.UserID);
                }
				else
				{
					repeatCount++;
				}
            }
            return repeatCount;
        }

		private decimal ItemsRecieved(List<Models.Transaction> transactionList)
		{
			decimal total = 0;
			foreach (var transaction in transactionList)
			{
                total += transaction.LineItems.Sum(x => x.Quantity);
            }
			return total;
		}


        private decimal AverageItemsRecieved(List<Models.Transaction> transactionList)
        {
            decimal total = 0;
            foreach (var transaction in transactionList)
            {
                total += transaction.LineItems.Sum(x=>x.Quantity);
            }
            return total / transactionList.Count;
        }


        private decimal DonatedByRG(List<Models.Transaction> transactionList)
        {
            decimal total = 0;
            foreach (var transaction in transactionList)
            {
                transaction.LineItems.ForEach(line =>
                {
                    if (line.IsRG)
                    {
                        total += line.Quantity;
                    }
                });
                
            }
            return total;
        }

        private decimal DonatedByPAL(List<Models.Transaction> transactionList)
        {
            decimal total = 0;
            foreach (var transaction in transactionList)
            {
                transaction.LineItems.ForEach(line =>
                {
                    if (line.IsPAL)
                    {
                        total += line.Quantity;
                    }
                });
            }
            return total;
        }


        private decimal MoneyDonated(List<Donation> donationList)
        {
            decimal total = 0;
            foreach (var donation in donationList)
            {
                if (donation.Type.Trim() == "Monetary")
                {
                    total += donation.Value;
                }
            }
            return total;
        }

        private decimal OtherDonated(List<Donation> donationList)
        {
            decimal total = 0;
            foreach (var donation in donationList)
            {
                if (donation.Type.Trim() != "Monetary")
                {
                    total += donation.Quantity;
                }
            }
            return total;
        }
    }
}
