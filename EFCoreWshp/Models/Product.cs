//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace EFCoreWshp.Models
//{
//    public class Product
//    {
//        public Product()
//        {
//        }

//        // primary key
//        [Key]
//        public Guid Id { get; set; }

//        // columns
//        [Required]
//        [MaxLength(36)]
//        [Column("colName")]
//        public string Name { get; set; }

//        // datatype: float
//        // string can be null, but float & int cannot be null.
//        // if you really want it to be null, put the question mark
//        // public float? Price { get; set; }
//        [Column("colPrice")]
//        public float Price { get; set; }
     
//        // datatype: int
//        [Column("colQuantity")]
//        public int Quantity { get; set; }

        
//    }
//}
