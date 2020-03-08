using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RestApi.Models
{
    public class Product
    {
        [Key]
        public int prod_id {get;set;}
        [Required] 
        public string prod_name {get;set;}
        [Required]
        public string prod_body {get;set;}
    }
}