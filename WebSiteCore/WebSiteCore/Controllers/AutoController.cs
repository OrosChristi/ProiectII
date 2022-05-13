using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteCore.Models;
using WebSiteCore.ViewModels;

namespace WebSiteCore.Controllers
{  
    public class AutoController : Controller
    { 
        private readonly DataBaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AutoController(DataBaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Auto
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auto.ToListAsync());
        }
        public async Task<IActionResult> List()
        {
            var auto = await _context.Auto.Include(a => a.Photos).ToListAsync();

            return View(auto);
        }

        // GET: Auto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }
        public async Task<IActionResult> AutoDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto =   await _context.Auto.Where(x => x.ID == id)
                 .Select(car => new AutoViewModel()
                 {
                     Name = car.Name,
                     Km = car.Km,
                    Brand = car.Brand,
                    Price = car.Price,
                    Power = car.Power,
                    EngineCapacity = car.EngineCapacity,
                    Transmission = car.Transmission,
                    Year = car.Year,
                     Photos = car.Photos.Select(g => new PhotoViewModel()
                     {
                         PhotoId = g.PhotoId,
                        
                         UrlPath = g.UrlPath
                     }).ToList(),
                     
                 }).FirstOrDefaultAsync();

            return View(auto);
        }



        // GET: Auto/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AutoAddViewModel auto)
        {
            if (ModelState.IsValid)
            {
                var newauto = new Auto()
                {Name = auto.Name,
                Brand = auto.Brand,
                    Km = auto.Km,
                    Price = auto.Price,
                    Transmission = auto.Transmission,
                    Year = auto.Year,
                    Power=auto.Power,
                    EngineCapacity=auto.EngineCapacity,

                };
                if(auto.PhotoFiles != null)
                {
                    string folder = "Images/";

                    newauto.Photos = new List<Photo>();

                    foreach (var file in auto.PhotoFiles)
                    {
                        var gallery = new Photo()
                        {
                           
                            UrlPath = await UploadImage(folder, file)
                        };
                        newauto.Photos.Add(gallery);
                    }
                }
               
                _context.Add(newauto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }

        // GET: Auto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Brand,Name,Year,Km,Transmission,Power,EngineCapacity,Price")] Auto auto)
        {
            if (id != auto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }

        // GET: Auto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Auto.FindAsync(id);
            _context.Auto.Remove(auto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Auto.Any(e => e.ID == id);
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
