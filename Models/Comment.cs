using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Comment
    {
        [Key]
        public int commentId {get;set;}
        [Required]
        public string commentBody {get;set;}
        [Required]
        public int postId {get;set;}    
    }
}