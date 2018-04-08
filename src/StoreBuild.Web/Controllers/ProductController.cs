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
    public class ProductController : Controller
    {
        private readonly ProductStorer _productStorer;

        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductController(ProductStorer productStorer,
            IRepository<Category> categoryRepository,
            IRepository<Product> productRepository)
        {
            _productStorer = productStorer;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.All();
            if (products.Any())
            {
                var viewModel = products.Select(c => new ProductViewModel() { Id = c.Id, Name = c.Name, CategoryName = c.Category.Name });
                return View(viewModel);
            }
            else
                return View(new List<ProductViewModel>());
        }
        public IActionResult CreateOrEdit(int id)
        {
            var viewModel = new ProductViewModel();
            var categories = _categoryRepository.All();
            if(categories.Any())
                viewModel.Categories = categories.Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name}).AsEnumerable();

            if (id > 0)
            {
                var product = _productRepository.GetById(id);
                viewModel.Id = product.Id;
                viewModel.Name = product.Name;
                viewModel.CategoryId = product.Category.Id;
                viewModel.Price = product.Price;
                viewModel.StockQuantity = product.StockQuantity;
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateOrEdit(ProductViewModel dto)
        {
            _productStorer.Store(dto.Id, dto.Name, dto.CategoryId, dto.Price, dto.StockQuantity);
            return RedirectToAction("Index");
        }
    }
}
