using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products.Models;

[Table("Product")]
public class Product
{
    [Key]
    [Column("product_id")]
    public int product_id { get; set; }
    [Column("product_name")]
    public string product_name { get; set; }
    [Column("product_description")]
    public string product_description { get; set; }
    [Column("product_image")]
    public string product_image { get; set; }
    [Column("product_price")]
    public decimal product_price { get; set; }
    [Column("product_quantity")]
    public int product_quantity { get; set; }
}
