using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public virtual ICollection<Comment> Comments {get;set;}

    }
}