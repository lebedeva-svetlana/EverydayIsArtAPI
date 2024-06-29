namespace EverydayIsArtAPI.Models
{
    public class FavouritesGroup
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Title { get; set; }

        //  public bool isVisible { get; set; }

        public List<Art> Items { get; } = [];
    }
}