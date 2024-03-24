using System.ComponentModel.DataAnnotations;

namespace newshub.Models
{
    public class ApiResponse
    {
        public int TotalArticles { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
    }

    
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public Source Source { get; set; } = new Source();
    }

    
    public class Source
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
    //public class Favorite
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    public int UserId { get; set; } // Foreign key to the user

    //    // Other properties of the favorite article
    //    public string ArticleTitle { get; set; }
    //    // Add other properties as needed
    //}

}
