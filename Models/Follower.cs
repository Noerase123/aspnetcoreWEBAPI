using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Follower
    {
        [Key]
        public int followerId {get;set;}
        [Required]
        public int followerCount {get;set;}
    }
}