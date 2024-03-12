using System.ComponentModel.DataAnnotations;

namespace newshub.Models
{
    public class cardData1
    {
        [Key]
        public int cardID { get; set; }
        public string ImgSrc { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string Channel { get; set; }
        public string VedioLink { get; set; }

      /*  public List<Favorite> Favorites { get; set; } = new List<Favorite>();*/


    }
   /* public class Favorite
    {
        [Key]
        public int ID { get; set; }
        public int userID { get; set; }
        public Register User { get; set; }
        public int cardID { get; set; }

        public cardData1 Card { get; set; }

        
    }*/

}