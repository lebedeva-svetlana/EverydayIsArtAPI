namespace EverydayIsArtAPI.Models
{
    public class Art
    {
        public string? Title { get; set; }

        public string? Date { get; set; }

        public IList<string>? Author { get; set; }

        public IList<DescriptionGroup>? Description { get; set; }

        public string ImageUrl { get; set; }

        public string SourceUrl { get; set; }

        public string SourceUrlText { get; set; }
    }
}