using CapstoneProject.Data;
using CapstoneProject.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class SubcategoriesController : Controller
    {

        private readonly CapstoneProjectDbContext _db;
        private readonly ILogger<UserController> _logger;

        public SubcategoriesController(CapstoneProjectDbContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();

            var catList = await _db.ItemCategories.ToListAsync();
            for (int i = 0; i < catList.Count(); i++)
            {
                CategoryDTO dto = new CategoryDTO();
                dto.category = catList[i];
                dto.subcategories = _db.ItemSubcategories.Where(x => x.CategoryID == catList[i].CategoryID).ToList();
                dtoList.Add(dto);
            }

            return View(dtoList);
        }

        public IActionResult Add()
        {
            return View(_db.ItemCategories.ToList());
        }

        [HttpPost]
        public IActionResult Add([FromBody] ItemSubcategory model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    string name = model.Name.ToUpper();
                    if (_db.ItemCategories.All(x => x.Name.ToUpper() != name))
                    {

                        _db.ItemSubcategories.Add(model);
                        _db.SaveChanges();

                        return Ok();
                    }
                    else
                    {
                        throw new Exception("Category already exists");
                    }
                }
                else
                {
                    throw new Exception("Posted category was null or whitespace");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}\t{ex.Message}\n");
                return BadRequest();
            }
        }


        public IActionResult Edit(int id)
        {
            return View(_db.ItemSubcategories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit([FromBody] ItemSubcategory subcategory)
        {


            try
            {
                if (subcategory == null || string.IsNullOrEmpty(subcategory.Name)) throw new Exception("The subcategory or it's name was null or empty");
                if (!ModelState.IsValid) throw new Exception("Invalid model state");
                //if (_db.ItemSubcategories.Select(x => x.Name.ToUpper()).Contains(subcategory.Name.ToUpper())) throw new Exception($"The subcategory {subcategory.Name} already exists");

                string upperName = subcategory.Name.ToUpper();
                if(_db.ItemSubcategories.Any(x=>x.Name.ToUpper() == upperName && x.SubcategoryID != subcategory.SubcategoryID)) throw new Exception($"The subcategory {subcategory.Name} already exists");

                _db.ItemSubcategories.Update(subcategory);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}\t{ex.Message}\n");
                return BadRequest();
            }
        }
    }
}