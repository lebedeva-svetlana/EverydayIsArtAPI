namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     An exhibit.
    /// </summary>
    public class Art
    {
        /// <summary>
        ///     Gets or sets a title of an exhibit.
        /// </summary>
        /// <value>
        ///     The title of the exhibit.
        /// </value>
        public string? Title { get; set; }

        /// <summary>
        ///     Gets or sets a date of an exhibit creation.
        /// </summary>
        /// <value>
        ///     The date of the exhibit creation.
        /// </value>
        public string? Date { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit authors.
        /// </summary>
        /// <value>
        ///     The exhibit authors.
        /// </value>
        public IList<string>? Author { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit description.
        /// </summary>
        /// <value>
        ///     The exhibit description.
        /// </value>
        public IList<DescriptionGroup>? Description { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit image URL.
        /// </summary>
        /// <value>
        ///     The exhibit image URL.
        /// </value>
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit organization page URL.
        /// </summary>
        /// <value>
        ///     The exhibit organization page URL..
        /// </value>
        public string SourceUrl { get; set; }

        /// <summary>
        ///     Get or set an exhibit credit text.
        /// </summary>
        /// <value>
        ///     The exhibit credit text.
        /// </value>
        public string SourceUrlText { get; set; }
    }
}