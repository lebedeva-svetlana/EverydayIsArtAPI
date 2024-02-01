namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     A detailed description of an exhibit.
    /// </summary>
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

        /// <summary>
        ///     Gets or sets an exhibit description paragraphs.
        /// </summary>
        /// <value>
        ///     The exhibit description paragraphs.
        /// </value>
        public IList<string>? Parts { get; set; }
    }
}