using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles ="Admin,Staff")]
    public class CategoriesController : Controller
    {
        private readonly CapstoneProjectDbContext _db;
        private readonly ILogger<UserController> _logger;

        public CategoriesController(CapstoneProjectDbContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_db.ItemCategories.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {

                    if (!_db.ItemCategories.Select(x => x.Name.ToUpper()).Contains(name.ToUpper()))
                    {

                        _db.ItemCategories.Add(new ItemCategory() { Name = name });
                        _db.SaveChanges();

                        return Ok();
                    }
                    else
                    {
                        throw new Exception($"The category {name} already exists");
                    }
                }
                else
                {
                    throw new Exception("Posted category was null or the name only contained whitespace characters");
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
            return View(_db.ItemCategories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit([FromBody] ItemCategory category)
        {


            try
            {
                if (category == null || string.IsNullOrEmpty(category.Name)) throw new Exception("The category or it's name was null or empty");
                if (!ModelState.IsValid) throw new Exception("Invalid model state");
                if (_db.ItemCategories.Select(x => x.Name.ToUpper()).Contains(category.Name.ToUpper())) throw new Exception($"The category {category.Name} already exists");

                _db.ItemCategories.Update(category);
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