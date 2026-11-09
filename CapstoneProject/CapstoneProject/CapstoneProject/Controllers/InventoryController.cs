using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InventoryController : Controller
    {
        // The private readonly field that holds the instance of the ApplicationDbContext
        private readonly CapstoneProjectDbContext _db;
        public InventoryController(CapstoneProjectDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //List<Item> objInventoryList = _db.Items.ToList();
            //return View(objInventoryList);
            List<Item> objInventoryList = _db.Items
                .Include(i => i.ItemSubcategory)
                .ToList();
            return View(objInventoryList);
        }

        public IActionResult Create(Item obj)
        {
            return View(obj);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePOST([FromBody] Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Item created successfully";
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult Edit(Item obj)
        {
            Item objFromDb = _db.Items.Where(x => x.ItemID == obj.ItemID).Include(x => x.ItemSubcategory).SingleOrDefault();

            
            if (objFromDb == null)
            {
                return NotFound();
            }


            return View(objFromDb);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPOST([FromBody] Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj); // update item 
                _db.SaveChanges(); // save changes
                TempData["success"] = "Item updated successfully";
                return Ok();
            }
            return BadRequest();
        }


        public IActionResult Delete(string? itemId)
        {
            if (itemId == null)
            {
                return NotFound();
            }
            Item itemFromDb = _db.Items.Find(int.Parse(itemId));
            if (itemFromDb == null)
            {
                return NotFound();
            }

            // Get subcategory name
            var subcategory = _db.ItemSubcategories.FirstOrDefault(sc => sc.SubcategoryID == itemFromDb.SubcategoryID);
            ViewBag.SubcategoryName = subcategory != null ? subcategory.Name : "Unknown";


            return View(itemFromDb);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(string? itemId)
        {
            Item obj;
            try
            {
                obj = _db.Items.Find(int.Parse(itemId));
            }
            catch
            {
                return BadRequest();
            }
            if(obj == null)
            {
                return NotFound();
            }
            _db.Items.Remove(obj); // remove Item 
            _db.SaveChanges(); // save changes 
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("LookUp", "Inventory");
           
        }

        public IActionResult LookUp()
        {
            //List<Item> objInventoryList = _db.Items.ToList();
            //ViewBag.InventoryList = objInventoryList;
            List<Item> objInventoryList = _db.Items
                .Include(i => i.ItemSubcategory)
                .ToList();
            ViewBag.InventoryList = objInventoryList;

            return View();
        }

        [HttpPost, ActionName("LookUp")]
        public IActionResult LookUpPost(Item obj)
        {
                if (_db.Items.Any(item => item.UUID == obj.UUID))
                {
                    Item existingItem = _db.Items.FirstOrDefault(item => item.UUID == obj.UUID);
                    if (existingItem != null)
                    {
                        return RedirectToAction("Edit", existingItem);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                else
                {
                    return RedirectToAction("Create", obj);
                }
        }






    }
}
