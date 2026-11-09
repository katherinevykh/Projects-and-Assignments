--Data brought to you by ChatGPT


-- Delete all records for items/subcategories/categories
DELETE FROM Items;
DELETE FROM ItemSubcategories;
DELETE FROM ItemCategories;

-- Reset identity columns
DBCC CHECKIDENT ('Items', RESEED, 0);
DBCC CHECKIDENT ('ItemSubCategories', RESEED, 0);
DBCC CHECKIDENT ('ItemCategories', RESEED, 0);

-- Insert Categories
INSERT INTO ItemCategories VALUES ('Food');           -- ID 1
INSERT INTO ItemCategories VALUES ('Non-Food');       -- ID 2
INSERT INTO ItemCategories VALUES ('Produce');        -- ID 3
INSERT INTO ItemCategories VALUES ('Grab-N-Go');      -- ID 4
INSERT INTO ItemCategories VALUES ('Beverages');      -- ID 5
INSERT INTO ItemCategories VALUES ('Personal Care');  -- ID 6

-- Insert Subcategories
-- Produce
INSERT INTO ItemSubcategories VALUES (3, 'Apples');
INSERT INTO ItemSubcategories VALUES (3, 'Bananas');
INSERT INTO ItemSubcategories VALUES (3, 'Berries');
INSERT INTO ItemSubcategories VALUES (3, 'Leafy Greens');

-- Non-Food
INSERT INTO ItemSubcategories VALUES (2, 'Medicine');
INSERT INTO ItemSubcategories VALUES (2, 'Cleaning Supplies');

-- Grab-N-Go (including Snacks now)
INSERT INTO ItemSubcategories VALUES (4, 'Granola Bars');
INSERT INTO ItemSubcategories VALUES (4, 'Sandwiches');
INSERT INTO ItemSubcategories VALUES (4, 'Yogurt Cups');
INSERT INTO ItemSubcategories VALUES (4, 'Chips');     -- formerly Snacks
INSERT INTO ItemSubcategories VALUES (4, 'Cookies');   -- formerly Snacks

-- Food
INSERT INTO ItemSubcategories VALUES (1, 'Noodles');
INSERT INTO ItemSubcategories VALUES (1, 'Mac n Cheese');
INSERT INTO ItemSubcategories VALUES (1, 'Canned Soup');
INSERT INTO ItemSubcategories VALUES (1, 'Frozen Meals');

-- Beverages
INSERT INTO ItemSubcategories VALUES (5, 'Soda');
INSERT INTO ItemSubcategories VALUES (5, 'Juice');
INSERT INTO ItemSubcategories VALUES (5, 'Water');
INSERT INTO ItemSubcategories VALUES (5, 'Coffee');

-- Personal Care
INSERT INTO ItemSubcategories VALUES (6, 'Toothpaste');
INSERT INTO ItemSubcategories VALUES (6, 'Shampoo');

-- Insert Items
-- Produce
INSERT INTO Items VALUES ('000000000001', 'Granny Smith Apple', 'Produce', 3, 1);
INSERT INTO Items VALUES ('000000000002', 'Honeycrisp Apple', 'Produce', 1, 1);
INSERT INTO Items VALUES ('000000000003', 'Fuji Apple', 'Produce', 0, 1);

INSERT INTO Items VALUES ('000000000004', 'Organic Banana Bunch', 'Produce', 2, 2);
INSERT INTO Items VALUES ('000000000005', 'Conventional Bananas', 'Produce', 1, 2);

INSERT INTO Items VALUES ('000000000006', 'Strawberries Pint', 'Produce', 4, 3);
INSERT INTO Items VALUES ('000000000007', 'Blueberries Pint', 'Produce', 0, 3);

INSERT INTO Items VALUES ('000000000008', 'Romaine Lettuce Bag', 'Produce', 1, 4);
INSERT INTO Items VALUES ('000000000009', 'Spinach Clamshell', 'Produce', 2, 4);

-- Non-Food
INSERT INTO Items VALUES ('000000000010', 'Tylenol 500mg', 'Non-Food', 2, 5);
INSERT INTO Items VALUES ('000000000011', 'Ibuprofen 200mg', 'Non-Food', 0, 5);
INSERT INTO Items VALUES ('000000000012', 'Advil Liquid Gels', 'Non-Food', 1, 5);

INSERT INTO Items VALUES ('000000000013', 'Clorox Wipes', 'Non-Food', 1, 6);
INSERT INTO Items VALUES ('000000000014', 'Lysol Spray', 'Non-Food', 0, 6);
INSERT INTO Items VALUES ('000000000015', 'Mr. Clean Magic Eraser', 'Non-Food', 2, 6);

-- Grab-N-Go
INSERT INTO Items VALUES ('000000000016', 'Quaker Chewy Chocolate Chip', 'Grab-N-Go', 3, 7);
INSERT INTO Items VALUES ('000000000017', 'Nature Valley Oats & Honey', 'Grab-N-Go', 2, 7);
INSERT INTO Items VALUES ('000000000018', 'KIND Bar Almond & Sea Salt', 'Grab-N-Go', 0, 7);

INSERT INTO Items VALUES ('000000000019', 'Ham & Cheese Sandwich', 'Grab-N-Go', 1, 8);
INSERT INTO Items VALUES ('000000000020', 'Turkey Club Sandwich', 'Grab-N-Go', 2, 8);

INSERT INTO Items VALUES ('000000000021', 'Chobani Vanilla Yogurt', 'Grab-N-Go', 1, 9);
INSERT INTO Items VALUES ('000000000022', 'FAGE Greek Yogurt', 'Grab-N-Go', 0, 9);

INSERT INTO Items VALUES ('000000000023', 'Lays Classic Chips', 'Grab-N-Go', 3, 10);
INSERT INTO Items VALUES ('000000000024', 'Doritos Nacho Cheese', 'Grab-N-Go', 1, 10);
INSERT INTO Items VALUES ('000000000025', 'Kettle Chips Sea Salt', 'Grab-N-Go', 2, 10);

INSERT INTO Items VALUES ('000000000026', 'Oreo Cookies 6-pack', 'Grab-N-Go', 2, 11);
INSERT INTO Items VALUES ('000000000027', 'Chips Ahoy Minis', 'Grab-N-Go', 0, 11);

-- Food
INSERT INTO Items VALUES ('000000000028', 'Spaghetti Noodles', 'Food', 2, 12);
INSERT INTO Items VALUES ('000000000029', 'Ramen Noodles Chicken', 'Food', 1, 12);
INSERT INTO Items VALUES ('000000000030', 'Whole Wheat Penne', 'Food', 1, 12);

INSERT INTO Items VALUES ('000000000031', 'Kraft Mac N Cheese', 'Food', 3, 13);
INSERT INTO Items VALUES ('000000000032', 'Velveeta Shells & Cheese', 'Food', 0, 13);

INSERT INTO Items VALUES ('000000000033', 'Campbell’s Chicken Noodle Soup', 'Food', 1, 14);
INSERT INTO Items VALUES ('000000000034', 'Progresso Tomato Basil', 'Food', 2, 14);

INSERT INTO Items VALUES ('000000000035', 'Amy’s Frozen Lasagna', 'Food', 1, 15);
INSERT INTO Items VALUES ('000000000036', 'Stouffer’s Mac n Cheese Frozen', 'Food', 0, 15);

-- Beverages
INSERT INTO Items VALUES ('000000000037', 'Coca-Cola 12oz Can', 'Beverages', 2, 16);
INSERT INTO Items VALUES ('000000000038', 'Pepsi 12oz Can', 'Beverages', 0, 16);

INSERT INTO Items VALUES ('000000000039', 'Tropicana Orange Juice', 'Beverages', 1, 17);
INSERT INTO Items VALUES ('000000000040', 'Apple & Eve Juice Box', 'Beverages', 2, 17);

INSERT INTO Items VALUES ('000000000041', 'Dasani Water Bottle', 'Beverages', 3, 18);
INSERT INTO Items VALUES ('000000000042', 'Poland Spring Water', 'Beverages', 1, 18);

INSERT INTO Items VALUES ('000000000043', 'Starbucks Cold Brew', 'Beverages', 2, 19);

-- Personal Care
INSERT INTO Items VALUES ('000000000044', 'Colgate Toothpaste', 'Personal Care', 1, 20);