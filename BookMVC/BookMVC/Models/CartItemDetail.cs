using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookMVC.Models
{
     public class CartItemDetail
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.None)]
          public long ItemID { get; set; }

          public int? Quantity { get; set; }

          [StringLength(250)]
          public string Name { get; set; }

          [StringLength(50)]
          public string Author { get; set; }

          [StringLength(250)]
          public string Image { get; set; }

          public decimal? Price { get; set; }

          [StringLength(250)]
          public string MetaTitle { get; set; }
          
          public decimal? Inventory { get; set; }
     }
}