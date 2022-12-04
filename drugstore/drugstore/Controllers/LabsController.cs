using drugstore.Data;
using drugstore.Models;
using drugstore.Models.ViewModel;
using drugstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Controllers
{
    public class LabsController : Controller
    {

        private readonly drugstoreContext _context;

        public LabsController(drugstoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var list = _context.Lab.ToList();

            return View(list);
        }

        public IActionResult Create()
        {
    
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lab lab)
        {
      
            _context.Lab.Add(lab);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = _context.Lab.FirstOrDefault(lab => lab.Id == id);

            var medicineAttributed = _context.Medicine.FirstOrDefault(med => med.LabId == id);

            if (lab == null)
            {
                return NotFound(nameof(lab));
            }

            if(medicineAttributed != null)
            {
                return RedirectToAction("DeleteError", "Labs", new { @id = id });
            }

            return View(lab);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var lab = _context.Lab.Find(id);

            if (lab == null)
            {
                return NotFound();
            }

            _context.Lab.Remove(lab);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteError(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new LabFormViewModel();
            viewModel.Medicines = _context.Medicine.Where(med => med.LabId == id).ToList();


            if (viewModel.Medicines == null)
            {
                return NotFound(nameof(viewModel.Medicines));
            }

            return View(viewModel.Medicines);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            Lab lab = _context.Lab.FirstOrDefault(s => s.Id == id);

            if (lab == null) return NotFound();

            return View(lab);
        }

        [HttpPost]
        public IActionResult Edit(Lab lab)
        {
            _context.Lab.Update(lab);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

     }


 }

