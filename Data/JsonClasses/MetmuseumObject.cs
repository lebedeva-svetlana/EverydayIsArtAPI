using System.Text.Json.Serialization;

namespace EverydayIsArtAPI.Data
{
    /// <summary>
    ///     A JSON of The Metropolitan Museum of Art API.
    /// </summary>
    public class MetmuseumObject
    {
        [JsonPropertyName("accessionNumber")]
        public string AccessionNumber { get; set; }

        [JsonPropertyName("primaryImage")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("constituents")]
        public Constituent[] Authors { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("culture")]
        public string Culture { get; set; }

        [JsonPropertyName("artistDisplayName")]
        public string AuthorDisplayName { get; set; }

        [JsonPropertyName("objectDate")]
        public string Date { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("dimensions")]
        public string Dimensions { get; set; }

        [JsonPropertyName("creditLine")]
        public string CreditLine { get; set; }

        [JsonPropertyName("geographyType")]
        public string GeographyType { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("objectURL")]
        public string SourceURL { get; set; }
    }

    public class Constituent
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}