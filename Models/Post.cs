using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Post
    {
        [Key]
        public int postId {get;set;}
        [Required]
        public string name {get;set;}
        [Required]
        public string address {get;set;}
        [Required]
        public int age {get;set;}

    }
}