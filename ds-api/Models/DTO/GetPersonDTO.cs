namespace discounts_salling_api.Models.DTO;

public class GetProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public static Product ToProduct(GetProductDto getProductDto)
    {
        return new Product
        {
            Id = getProductDto.Id,
            Name = getProductDto.Name
        };
    }
}