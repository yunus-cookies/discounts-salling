using System.ComponentModel.DataAnnotations;

namespace discounts_salling_api.Models.DTO;


public class CreateProductDTO
{
    [Required]
    public required string Name { get; set; }

    public static Product ToProduct(CreateProductDTO createProductDto)
    {
        return new Product
        {
            Name = createProductDto.Name
        };
    }
}