using DapperProject.Dtos.ProductDtos;
using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace DapperProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values=await _productService.GetAllProductWithCategoryAsync();
            ViewBag.v = await _productService.GetAllProductAsync();
            return View(values);

        }
    }
}

