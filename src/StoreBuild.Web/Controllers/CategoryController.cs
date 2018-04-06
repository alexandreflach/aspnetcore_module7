﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreBuild.Domain.Dtos;
using StoreBuild.Domain.Products;
using StoreBuild.Web.Models;
using StoreBuild.Web.ViewsModels;

namespace StoreBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryStorer _categoryStorer;

        public CategoryController(CategoryStorer categoryStorer)
        {
            _categoryStorer = categoryStorer;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel dto)
        {
            _categoryStorer.Store(dto.Id, dto.Name);
            return View();
        }
    }
}
