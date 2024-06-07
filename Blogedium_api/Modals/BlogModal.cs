using System.ComponentModel.DataAnnotations;

namespace Blogedium_api.Modals
{
    public class BlogModal
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Please upload an Image")]
        public string Image {get; set;}

        [Required(ErrorMessage = "Enter the title")]
        public string Title {get; set;}

        [Required(ErrorMessage = "Enter a comment")]
        public string Content {get; set;}

        public BlogModal(int id , string image, string title, string content)
        {
            Id = id;
            Image = image;
            Title = title;
            Content = content;
        }
    }
}