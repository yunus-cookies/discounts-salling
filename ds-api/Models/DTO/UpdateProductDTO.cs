using System.ComponentModel.DataAnnotations;

namespace discounts_salling_api.Models.DTO;

public class UpdateProductDTO
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public static Product ToProduct(UpdateProductDTO updateProductDto)
    {
        return new Product
        {
            Id = updateProductDto.Id,
            Name = updateProductDto.Name
        };
    }
}