namespace EverydayIsArtAPI.Models
{
    public class DescriptionGroup
    {
        public DescriptionGroup(string part)
        {
            Parts = new List<string>() { part };
        }

        public DescriptionGroup(IList<string> parts)
        {
            Parts = parts;
        }

        public IList<string>? Parts { get; set; }
    }
}