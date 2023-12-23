using System.Text.Json.Serialization;

namespace EverydayIsArtAPI.Data.VamGallery
{
    public class VamGallery
    {
        [JsonPropertyName("records")]
        public Record[] Objects { get; set; }
    }

    public class Record
    {
        [JsonPropertyName("systemNumber")]
        public string ObjectNumber { get; set; }
    }
}