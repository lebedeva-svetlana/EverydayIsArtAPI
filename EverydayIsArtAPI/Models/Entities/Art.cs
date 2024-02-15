namespace EverydayIsArtAPI.Models
{
    /// <summary>
    ///     An exhibit.
    /// </summary>
    public class Art
    {
        /// <summary>
        ///     Gets or sets an ID of an art.
        /// </summary>
        /// <value>
        ///     The ID of the art.
        /// </value>
        public int Id { get; set; }

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
        ///     Gets or sets exhibit authors.
        /// </summary>
        /// <value>
        ///     The exhibit authors.
        /// </value>
        public IList<string>? Author { get; set; }

        /// <summary>
        ///     Gets or sets a places of origin of an exhibit.
        /// </summary>
        /// <value>
        ///     The places of origin of the exhibit.
        /// </value>
        public IList<string>? PlaceOfOrigin { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit medium.
        /// </summary>
        /// <value>
        ///     The exhibit medium.
        /// </value>
        public IList<string>? Medium { get; set; }

        /// <summary>
        ///     Gets or sets an access number of an exhibit.
        /// </summary>
        /// <value>
        ///     The access number of the exhibit.
        /// </value>
        public string? AccessNumber { get; set; }

        /// <summary>
        ///     Gets or sets sources of an exhibit.
        /// </summary>
        /// <value>
        ///     The sources of the exhibit.
        /// </value>
        public IList<string>? WayToGet { get; set; }

        /// <summary>
        ///     Gets or sets an exhibit description.
        /// </summary>
        /// <value>
        ///     The exhibit description.
        /// </value>
        public IList<string>? Description { get; set; }

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