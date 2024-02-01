using System.Text.Json.Serialization;

namespace EverydayIsArtAPI.Data.VamObject
{
    public class VamObject
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("record")]
        public Record Record { get; set; }
    }

    public class Artist
    {
        [JsonPropertyName("association")]
        public Association Association { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }

    public class Association
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Date
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Dimension
    {
        [JsonPropertyName("dimension")]
        public string ObjectDimension { get; set; }

        [JsonPropertyName("part")]
        public string Part { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("_primary_thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("images")]
        public Images Images { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Parttype
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Placesoforigin
    {
        [JsonPropertyName("association")]
        public Association Association { get; set; }

        [JsonPropertyName("place")]
        public Place Place { get; set; }
    }

    public class Productiondate
    {
        [JsonPropertyName("association")]
        public Association Association { get; set; }

        [JsonPropertyName("date")]
        public Date Date { get; set; }
    }

    public class Record
    {
        [JsonPropertyName("accessionNumber")]
        public string AccessionNumber { get; set; }

        [JsonPropertyName("artistMakerPerson")]
        public Artist[] Artists { get; set; }

        [JsonPropertyName("briefDescription")]
        public string BriefDescription { get; set; }

        [JsonPropertyName("creditLine")]
        public string CreditLine { get; set; }

        [JsonPropertyName("dimensions")]
        public Dimension[] Dimensions { get; set; }

        [JsonPropertyName("images")]
        public string[] ImagesNumbers { get; set; }

        [JsonPropertyName("materialsAndTechniques")]
        public string Materials { get; set; }

        [JsonPropertyName("partTypes")]
        public Parttype[][] PartTypes { get; set; }

        [JsonPropertyName("placesOfOrigin")]
        public Placesoforigin[] PlacesOfOrigin { get; set; }

        [JsonPropertyName("productionDates")]
        public Productiondate[] ProductionDates { get; set; }

        [JsonPropertyName("summaryDescription")]
        public string Summary { get; set; }

        [JsonPropertyName("systemNumber")]
        public string SystemNumber { get; set; }

        [JsonPropertyName("titles")]
        public Title[] Titles { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("title")]
        public string ObjectTitle { get; set; }
    }
}