using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogedium_api.Modals
{
    public class BlogModal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please upload an Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter a comment")]
        public string Content { get; set; }

        // Navigation property for comments
        public ICollection<CommentModal> Comments { get; set; }

        public BlogModal()
        {
            Comments = new List<CommentModal>();
        }
    }
}
