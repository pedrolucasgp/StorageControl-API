using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageControl.Models;
using StorageControl.Repositories;
using StorageControl.Repositories.Interfaces;

namespace StorageControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> ListAll()
        {
            List<ProductModel> products = await _productRepository.ListAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> FindById(int id)
        {
            ProductModel product = await _productRepository.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Add([FromBody] ProductModel productModel)
        {
            ProductModel product = await _productRepository.Add(productModel);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> Update([FromBody] ProductModel productModel, int id)
        {
            productModel.Id = id;
            ProductModel product = await _productRepository.Update(productModel, id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> Delete(int id)
        {
            bool deleted = await _productRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
