using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using discounts_salling_api.Models.DTO;

namespace discounts_salling_api.Models;

[Table("Product")]
public class Product
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(30)")]
    [Required]
    public required string Name { get; set; }

    public static GetProductDto ToGetProductDto(Product product)
    {
        return new GetProductDto
        {
            Id = product.Id,
            Name = product.Name
        };
    }

}