using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook.Utils;

namespace PhoneBook.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IRepository _repo;

        public EntriesController(IRepository repo)
        {
            _repo = repo;    
        }

       public async Task<IActionResult> Index(string sortOrder,
        string currentFilter,
        string searchString,
        int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PhoneSortParm"] = String.IsNullOrEmpty(sortOrder) ? "phone_desc" : "";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var entry = from e in _repo.GetAllEntries().Skip(0)
                       select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                entry = entry.Where(e => e.Name.Contains(searchString)
                                       || e.PhoneNumber.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    entry = entry.OrderByDescending(p => p.Name);
                    break;
                default:
                case "phone_desc":
                    entry = entry.OrderBy(p => p.PhoneNumber);
                    break;
             
               
                 
            }
            int pageSize = 5;
            return View(await PaginatedList<Entry>.CreateAsync(entry.AsNoTracking(), page ?? 1, pageSize));
            //            return View( _repo.GetAllEntries());
        }
     
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EntryId,Name,PhoneNumber")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntry(entry);
                return RedirectToAction("Index");
            }
            return View(entry);
        }

       
    }
}
