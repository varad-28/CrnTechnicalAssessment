using Application.DTOs;
using Application.Interfaces;
using Asp.Versioning;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IValidator<CreateProductDto> _validator;

    public ProductsController(
        IProductService productService,
        IValidator<CreateProductDto> validator)
    {
        _productService = productService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var products = await _productService.GetAllProductsAsync(pageNumber, pageSize);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
    {
        var validationResult = await _validator.ValidateAsync(createProductDto);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var createdProduct = await _productService.CreateProductAsync(createProductDto);

        return CreatedAtAction(nameof(Get), new { id = createdProduct.Id, version = "1.0" }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDto updateProductDto)
    {
        if (id != updateProductDto.Id)
            return BadRequest("ID mismatch");

        var updatedProduct = await _productService.UpdateProductAsync(updateProductDto);

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedProduct = await _productService.DeleteProductAsync(id);

        if (deletedProduct == null)
            return NotFound();

        return Ok(deletedProduct);
    }
}