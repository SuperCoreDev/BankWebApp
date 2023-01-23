﻿using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    public class LoanApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoanService _loanService;

        public LoanApplicationController(ApplicationDbContext context, ILoanService loanService)
        {
            _context = context;
            _loanService = loanService;
        }

        [Authorize(Roles = "Worker")]
        public async Task<IActionResult> Index()
        {
            return View(_loanService.GetAllLoans());
        }

        // TODO
        [Authorize(Roles = "Worker")]
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: LoanApplicationController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: LoanApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromForm] LoanViewModel loanModel)
        {
            var clientId = _context.Clients
                .Where(c => c.Email == User.Identity.Name)
                .Select(id => id.Id)
                .FirstOrDefault();

            if (ModelState.IsValid)
            {
                await _loanService.SendLoanApplication(loanModel, clientId);
            }
			return RedirectToAction("LoanApplication", "Home");

		}

        // GET: LoanApplicationController/Edit/5
        //[Authorize(Roles = "Worker")]
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: LoanApplicationController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Worker")]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: LoanApplicationController/Delete/5
        //[Authorize(Roles = "Worker")]
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: LoanApplicationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Worker")]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}