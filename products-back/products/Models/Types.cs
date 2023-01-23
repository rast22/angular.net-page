using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products.Models;


[Table("product_types")]
public class Types
{
    [Key]
    [Column("type_id")]
    public int type_id { get; set; }
    [Column("type_name")]
    public string type_name { get; set; }
}
