

using Microsoft.AspNetCore.Mvc;
using discounts_salling_api.Models.DTO;
using discounts_salling_api.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ApplicationDbContext dbContext;

    public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
    {
        dbContext = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        try
        {
            IEnumerable<Product> products = await dbContext.Products.AsNoTracking().ToListAsync();
            return Ok(products.Select(Product.ToGetProductDto));
        }

        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        try
        {
            Product? product = await dbContext.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (product is null)
            {
                return NotFound();
            }
            return Ok(Product.ToGetProductDto(product));
        }

        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync([FromBody] CreateProductDTO createProductDto)
    {
        try
        {
            Product product = CreateProductDTO.ToProduct(createProductDto);
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return Ok(Product.ToGetProductDto(product));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] UpdateProductDTO productToUpdate)
    {

        if (id != productToUpdate.Id)
        {
            return BadRequest($"id in parameter and id in body is different. id in parameter: {id}, id in body: {productToUpdate.Id}");
        }
        try
        {
            Product product = UpdateProductDTO.ToProduct(productToUpdate);
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return Ok(Product.ToGetProductDto(product));

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductByIdAsync(int id)
    {

        try
        {
            Product? product = await dbContext.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (product is null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


}