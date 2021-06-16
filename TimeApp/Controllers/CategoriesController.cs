using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeApp.Models;
using TimeApp.ViewModels;

namespace TimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly TimeAppContext _context;

        public CategoriesController(TimeAppContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutCategory(int id, CategoryViewModel category)
        {
            Category inputCategory = _context.Categories.FindAsync(id).Result;
            inputCategory.Name = category.Name;
            _context.Entry(inputCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return "Can't add the category.";
                }
                else
                {
                    throw;
                }
            }

            return inputCategory.Name+" is changed!";
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostCategory(CategoryViewModel category)
        {
            Category newCategory = new Category() {Name = category.Name };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return category.Name + " is added ";
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return $"Cant delete {category.Name}.";
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category.Name+" was deleted.";
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
