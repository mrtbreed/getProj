using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities {

    public class Product {
        // As Per Book

        [HiddenInput(DisplayValue =false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please Enter A Product Name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]

        [Required(ErrorMessage = "Please Enter A Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="Please Enter A Positive Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Please Specify a catigory")]
        public string Category { get; set; }

        //This method only sulpplies the name, price and category for fast mid level security change
        

        //[HiddenInput(DisplayValue = false)]
        //public int ProductID { get; set; }
        //public string Name { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public string Description { get; set; }
        //[DataType(DataType.MultilineText)]
        //public decimal Price { get; set; }
        //public string Category { get; set; }
    }
}
