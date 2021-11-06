using System.ComponentModel.DataAnnotations;

namespace aspnetblazor.Models
{

    public class Chapter
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Title is too long.")]
        public string ChapterNumber { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Post Post {get;set;}
        public int PostId {get;set;}
        public Chapter()
        {

        }


    }
}