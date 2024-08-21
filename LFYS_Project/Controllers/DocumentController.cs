using Microsoft.AspNetCore.Mvc;
using LFYS_Project.Models;
namespace LFYS_Project.Controllers
{
    public class DocumentController : Controller
    {
        WlfysProjContext _context = new WlfysProjContext();
        public IActionResult Index()
        {
            var documents = _context.Documents.ToList();
            return View(documents);
        }
        public IActionResult Detail(int id = 0)
        {
            var document = _context.Documents.Find(id);
            return View(document);
        }
        public async Task<IActionResult> Upload(string title, string content)
        {
            if(ModelState.IsValid)
            {
                Document document = new Document();
                document.Title = title;
                document.Description = content;

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}
