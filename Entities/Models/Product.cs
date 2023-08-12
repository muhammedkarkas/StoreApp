using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }

        //Her producta ait bir kategori bilgisi olacak
        public int? CategoryId { get; set; }  //Foreign Key
        public Category? Category { get; set; }  //Navigation Property
    }
}