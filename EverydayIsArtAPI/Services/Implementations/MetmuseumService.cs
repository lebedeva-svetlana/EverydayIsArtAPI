using EverydayIsArtAPI.Data;
using EverydayIsArtAPI.Models;
using System.Text.Json;

namespace EverydayIsArtAPI.Services
{
    /// <inheritdoc cref="IMetmuseumService"/>
    public class MetmuseumService : IMetmuseumService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MetmuseumService> _logger;
        private readonly HttpClient _httpClient = new();

        public MetmuseumService(IConfiguration config, ILogger<MetmuseumService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<Art> GetArt()
        {
            try
            {
                string objectUrl = await GetSourceUrl();
                var metmuseumObject = (MetmuseumObject?)await _httpClient.GetFromJsonAsync(objectUrl, typeof(MetmuseumObject));

                Art art = new();
                art.ImageUrl = metmuseumObject.ImageUrl;
                art.Title = metmuseumObject.Title;
                art.Date = Capitalize(metmuseumObject.Date);
                art.Author = GetAuthor(metmuseumObject);
                art.PlaceOfOrigin = GetPlaceOfOrigin(metmuseumObject);
                art.Medium = GetDimension(metmuseumObject);

                string? medium = GetMedium(metmuseumObject);
                if (medium != null)
                {
                    art.Medium?.Add(medium);
                }

                art.AccessNumber = GetAccessionNumber(metmuseumObject);
                art.WayToGet = GetWayToGet(metmuseumObject);
                art.SourceUrl = metmuseumObject.SourceURL;
                art.SourceUrlText = _config.GetValue<string>("SourceUrlText:Metmuseum");

                return art;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on Metmuseum art receiving.");
                return null;
            }
        }

        private string Capitalize(string text)
        {
            return char.ToUpper(text[0]) + text[1..];
        }

        private string? GetAccessionNumber(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.AccessionNumber.Length == 0 ? null : $"Accession number: {metmuseumObject.AccessionNumber}";
        }

        private List<string>? GetAuthor(MetmuseumObject metmuseumObject)
        {
            if (metmuseumObject.Authors is null && metmuseumObject.AuthorDisplayName.Length == 0)
            {
                return null;
            }

            List<string>? authors = new();

            if (metmuseumObject.Authors is null)
            {
                authors.Add(metmuseumObject.AuthorDisplayName);
                return authors;
            }

            for (int i = 0; i < metmuseumObject.Authors.Length; ++i)
            {
                string author = "";
                if (metmuseumObject.Authors.Length != 1)
                {
                    author += $"{metmuseumObject.Authors[i].Role}: ";
                }

                author += metmuseumObject.Authors[i].Name;
                if (author.ToLower() == "unknown")
                {
                    author += " artist";
                }

                authors.Add(author);
            }

            return authors;
        }

        private IList<string>? GetWayToGet(MetmuseumObject metmuseumObject)
        {
            string? way = metmuseumObject.CreditLine.Length == 0 ? null : metmuseumObject.CreditLine;
            if (way is null)
            {
                return null;
            }
            return new List<string>() { way };
        }

        private IList<string>? GetDimension(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.Dimensions.Length == 0 ? null : new List<string>() { $"Dimensions: {metmuseumObject.Dimensions}" };
        }

        private string? GetMedium(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.Medium == "" ? null : $"Materials: {metmuseumObject.Medium}";
        }

        private List<string>? GetPlaceOfOrigin(MetmuseumObject metmuseumObject)
        {
            if (metmuseumObject.GeographyType.Length == 0 && metmuseumObject.City.Length == 0 && metmuseumObject.State.Length == 0 && metmuseumObject.County.Length == 0 && metmuseumObject.County.Length == 0 && metmuseumObject.Culture.Length == 0)
            {
                return null;
            }

            string place = "";
            bool needComma = false;

            place += metmuseumObject.GeographyType;
            place += GetPlaceString(metmuseumObject.City, needComma, out needComma);
            place += GetPlaceString(metmuseumObject.State, needComma, out needComma);
            place += GetPlaceString(metmuseumObject.County, needComma, out needComma);
            place += GetPlaceString(metmuseumObject.Country, needComma, out _);

            place = place.Trim();

            if (place.Length == 0)
            {
                place = metmuseumObject.Culture;
            }

            return new List<string>() { place };
        }

        private string GetPlaceString(string place, bool needComma, out bool needNewComma)
        {
            string delimiter = " ";
            if (needComma)
            {
                delimiter = $",{delimiter}";
            }

            string placePart = place.Length != 0 ? delimiter + place : "";
            needNewComma = placePart.Length != 0 || needComma;

            return placePart;
        }

        private async Task<string> GetSourceUrl()
        {
            string jsonString = File.ReadAllText("Data/metmuseumIds.json");
            var gallery = JsonSerializer.Deserialize<int[]>(jsonString);
            int objectNumber = gallery[new Random().Next(0, gallery.Length)];
            return _config.GetValue<string>("URL:Metmuseum:ArtJson") + objectNumber;
        }
    }
}