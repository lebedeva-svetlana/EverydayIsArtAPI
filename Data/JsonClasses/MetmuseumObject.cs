using System.Text.Json.Serialization;

namespace EverydayIsArtAPI.Data
{
    public class MetmuseumObject
    {
        public int objectID { get; set; }
        public bool isHighlight { get; set; }

        [JsonPropertyName("accessionNumber")]
        public string AccessionNumber { get; set; }
        public string accessionYear { get; set; }
        public bool isPublicDomain { get; set; }

        [JsonPropertyName("primaryImage")]
        public string ImageUrl { get; set; }

        public string primaryImageSmall { get; set; }
        public string[] additionalImages { get; set; }

        [JsonPropertyName("constituents")]
        public Constituent[] Authors { get; set; }

        public string department { get; set; }
        public string objectName { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("culture")]
        public string Culture { get; set; }
        public string period { get; set; }
        public string dynasty { get; set; }
        public string reign { get; set; }
        public string portfolio { get; set; }
        public string artistRole { get; set; }
        public string artistPrefix { get; set; }

        [JsonPropertyName("artistDisplayName")]
        public string AuthorDisplayName { get; set; }

        public string artistDisplayBio { get; set; }
        public string artistSuffix { get; set; }
        public string artistAlphaSort { get; set; }
        public string artistNationality { get; set; }
        public string artistBeginDate { get; set; }
        public string artistEndDate { get; set; }
        public string artistGender { get; set; }
        public string artistWikidata_URL { get; set; }
        public string artistULAN_URL { get; set; }

        [JsonPropertyName("objectDate")]
        public string Date { get; set; }

        public int objectBeginDate { get; set; }
        public int objectEndDate { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("dimensions")]
        public string Dimensions { get; set; }
        public Measurement[] measurements { get; set; }

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
        public string region { get; set; }
        public string subregion { get; set; }
        public string locale { get; set; }
        public string locus { get; set; }
        public string excavation { get; set; }
        public string river { get; set; }
        public string classification { get; set; }
        public string rightsAndReproduction { get; set; }
        public string linkResource { get; set; }
        public DateTime metadataDate { get; set; }
        public string repository { get; set; }

        [JsonPropertyName("objectURL")]
        public string SourceURL { get; set; }
        public object tags { get; set; }
        public string objectWikidata_URL { get; set; }
        public bool isTimelineWork { get; set; }
        public string GalleryNumber { get; set; }
    }

    public class Measurement
    {
        public string elementName { get; set; }
        public object elementDescription { get; set; }
        public Elementmeasurements elementMeasurements { get; set; }
    }

    public class Elementmeasurements
    {
        public float Depth { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }

    public class Constituent
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}