using System.ComponentModel.DataAnnotations;

namespace Blogedium_api.Modals
{
    public class CommentModal
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
        [Required]
        public string CommentContent {get; set;}

        public CommentModal(int id , string firstname, string lastname, string  commentcontent)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            CommentContent = commentcontent;
        }
    }
}