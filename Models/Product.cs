using System.ComponentModel.DataAnnotations;

namespace MvcStore.Models;

public class Product{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string? ImageUrl { get; set; }
    public byte[]? Image { get; set; }
    public decimal? Price { get; set; }
    
}