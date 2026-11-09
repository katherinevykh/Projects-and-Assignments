using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class Schema06272025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EthAfricanAmerican = table.Column<bool>(type: "bit", nullable: false),
                    EthAsian = table.Column<bool>(type: "bit", nullable: false),
                    EthCaucasian = table.Column<bool>(type: "bit", nullable: false),
                    EthLatino = table.Column<bool>(type: "bit", nullable: false),
                    EthMiddleEastern = table.Column<bool>(type: "bit", nullable: false),
                    EthNativeAmerican = table.Column<bool>(type: "bit", nullable: false),
                    EthPacificIslander = table.Column<bool>(type: "bit", nullable: false),
                    EthOther = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendsSpartanburg = table.Column<bool>(type: "bit", nullable: false),
                    AttendsDowntown = table.Column<bool>(type: "bit", nullable: false),
                    AttendsCherokee = table.Column<bool>(type: "bit", nullable: false),
                    AttendsTygerRiver = table.Column<bool>(type: "bit", nullable: false),
                    AttendsUnion = table.Column<bool>(type: "bit", nullable: false),
                    HouseholdBabiesToddlers = table.Column<byte>(type: "tinyint", nullable: false),
                    HouseholdBabiesChildren = table.Column<byte>(type: "tinyint", nullable: false),
                    HouseholdTeens = table.Column<byte>(type: "tinyint", nullable: false),
                    HouseholdAdults = table.Column<byte>(type: "tinyint", nullable: false),
                    HasTransportation = table.Column<bool>(type: "bit", nullable: true),
                    Employed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployedHouseMembers = table.Column<byte>(type: "tinyint", nullable: false),
                    HasSNAP = table.Column<bool>(type: "bit", nullable: false),
                    HasWIC = table.Column<bool>(type: "bit", nullable: false),
                    HasTANF = table.Column<bool>(type: "bit", nullable: false),
                    IsInterestedInSNAP = table.Column<bool>(type: "bit", nullable: false),
                    IsInterestedInWIC = table.Column<bool>(type: "bit", nullable: false),
                    IsInterestedInTANF = table.Column<bool>(type: "bit", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    IsRegistrationComplete = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationID);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "LiabilityForms",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    RenewalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiabilityForms", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopTransactionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceRequests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    HouseholdAdults = table.Column<byte>(type: "tinyint", nullable: false),
                    HouseholdUnderage = table.Column<byte>(type: "tinyint", nullable: false),
                    Stove = table.Column<bool>(type: "bit", nullable: false),
                    Oven = table.Column<bool>(type: "bit", nullable: false),
                    Microwave = table.Column<bool>(type: "bit", nullable: false),
                    CanOpener = table.Column<bool>(type: "bit", nullable: false),
                    RunningWater = table.Column<bool>(type: "bit", nullable: false),
                    DietaryRestrictions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoupChili = table.Column<bool>(type: "bit", nullable: false),
                    SoupChicken = table.Column<bool>(type: "bit", nullable: false),
                    SoupTomato = table.Column<bool>(type: "bit", nullable: false),
                    SoupCream = table.Column<bool>(type: "bit", nullable: false),
                    SoupVegetable = table.Column<bool>(type: "bit", nullable: false),
                    SoupOther = table.Column<bool>(type: "bit", nullable: false),
                    RamenVegetable = table.Column<bool>(type: "bit", nullable: false),
                    RamenChicken = table.Column<bool>(type: "bit", nullable: false),
                    RamenShrimp = table.Column<bool>(type: "bit", nullable: false),
                    RamenBeef = table.Column<bool>(type: "bit", nullable: false),
                    RamenPork = table.Column<bool>(type: "bit", nullable: false),
                    RamenOther = table.Column<bool>(type: "bit", nullable: false),
                    CanMeatTuna = table.Column<bool>(type: "bit", nullable: false),
                    CanMeatOther = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableMix = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetablePeas = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableGreenBean = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableCorn = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableTomato = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableCarrot = table.Column<bool>(type: "bit", nullable: false),
                    CanVegetableOther = table.Column<bool>(type: "bit", nullable: false),
                    BeanCanned = table.Column<bool>(type: "bit", nullable: false),
                    BeanDry = table.Column<bool>(type: "bit", nullable: false),
                    BoxMealBeef = table.Column<bool>(type: "bit", nullable: false),
                    BoxMealChicken = table.Column<bool>(type: "bit", nullable: false),
                    BoxMealVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    BoxMealOther = table.Column<bool>(type: "bit", nullable: false),
                    SnackGranolaBar = table.Column<bool>(type: "bit", nullable: false),
                    SnackCrackers = table.Column<bool>(type: "bit", nullable: false),
                    SnackChips = table.Column<bool>(type: "bit", nullable: false),
                    SnackOther = table.Column<bool>(type: "bit", nullable: false),
                    CerealKids = table.Column<bool>(type: "bit", nullable: false),
                    CerealOatmeal = table.Column<bool>(type: "bit", nullable: false),
                    CerealBreakfastBar = table.Column<bool>(type: "bit", nullable: false),
                    OtherCannedFruit = table.Column<bool>(type: "bit", nullable: false),
                    OtherPeanutButter = table.Column<bool>(type: "bit", nullable: false),
                    OtherJelly = table.Column<bool>(type: "bit", nullable: false),
                    OtherMacNCheese = table.Column<bool>(type: "bit", nullable: false),
                    OtherMashedPotatoe = table.Column<bool>(type: "bit", nullable: false),
                    OtherRice = table.Column<bool>(type: "bit", nullable: false),
                    OtherPastaAndSauce = table.Column<bool>(type: "bit", nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRequests", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "UserSurveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreqServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedOtherPantries = table.Column<bool>(type: "bit", nullable: false),
                    NotEnoughFood = table.Column<bool>(type: "bit", nullable: false),
                    FreqFoodInadequate = table.Column<bool>(type: "bit", nullable: false),
                    PantryPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeedOpinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserClassYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurnedAwayStudent = table.Column<bool>(type: "bit", nullable: false),
                    TurnedAwayMoney = table.Column<bool>(type: "bit", nullable: false),
                    TurnedAwayOther = table.Column<bool>(type: "bit", nullable: false),
                    TurnedAwayNo = table.Column<bool>(type: "bit", nullable: false),
                    SkipMeal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecievedProtein = table.Column<bool>(type: "bit", nullable: false),
                    RecievedVegetables = table.Column<bool>(type: "bit", nullable: false),
                    RecievedFruit = table.Column<bool>(type: "bit", nullable: false),
                    RecievedDairy = table.Column<bool>(type: "bit", nullable: false),
                    RecievedGrains = table.Column<bool>(type: "bit", nullable: false),
                    RecievedPersonalCare = table.Column<bool>(type: "bit", nullable: false),
                    RecievedOther = table.Column<bool>(type: "bit", nullable: false),
                    AssistanceReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocateFunds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassActivities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassAttendance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGrades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEnrolled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserJobPerformance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserJobEmployed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCustService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserOpinionProducts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserOpinionServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserOpinionImprove = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserOpinionComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSurveys", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubcategories",
                columns: table => new
                {
                    SubcategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubcategories", x => x.SubcategoryID);
                    table.ForeignKey(
                        name: "FK_ItemSubcategories_ItemCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcategoryID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PointCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemSubcategories_SubcategoryID",
                        column: x => x.SubcategoryID,
                        principalTable: "ItemSubcategories",
                        principalColumn: "SubcategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLineItems",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsRG = table.Column<bool>(type: "bit", nullable: false),
                    IsPAL = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLineItems", x => new { x.TransactionID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_TransactionLineItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLineItems_Transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubcategoryID",
                table: "Items",
                column: "SubcategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubcategories_CategoryID",
                table: "ItemSubcategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLineItems_ItemID",
                table: "TransactionLineItems",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "LiabilityForms");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ResourceRequests");

            migrationBuilder.DropTable(
                name: "TransactionLineItems");

            migrationBuilder.DropTable(
                name: "UserSurveys");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ItemSubcategories");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
