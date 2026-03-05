using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace discounts_salling_api.Models;

[Table("Product")]
public class Product
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(30)")]
    [Required]
    public required string Name { get; set; }
}