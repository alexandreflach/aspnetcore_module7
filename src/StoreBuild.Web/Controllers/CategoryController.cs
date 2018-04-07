using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreBuild.Domain;
using StoreBuild.Domain.Dtos;
using StoreBuild.Domain.Products;
using StoreBuild.Web.Models;
using StoreBuild.Web.ViewsModels;

namespace StoreBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryStorer _categoryStorer;

        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStorer categoryStorer,
            IRepository<Category> categoryRepository)
        {
            _categoryStorer = categoryStorer;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            var viewModel = categories.Select(c => new CategoryViewModel() { Id = c.Id, Name = c.Name });
            return View(viewModel);
        }
        public IActionResult CreateOrEdit(int id)
        {
            if (id > 0)
            {
                var categorie = _categoryRepository.GetById(id);
                var dto = new CategoryViewModel() { Id = categorie.Id, Name = categorie.Name };
                return View(dto);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel dto)
        {
            _categoryStorer.Store(dto.Id, dto.Name);
            return RedirectToAction("Index");
        }
    }
}
