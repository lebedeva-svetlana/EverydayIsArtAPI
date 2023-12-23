using EverydayIsArtAPI.Data;
using EverydayIsArtAPI.Models;
using System.Text.Json;

namespace EverydayIsArtAPI.Services
{
    public class MetmuseumService : IMetmuseumService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient = new();

        public MetmuseumService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Art> GetArt()
        {
            string objectUrl = await GetSourceUrl();
            var metmuseumObject = (MetmuseumObject?)await _httpClient.GetFromJsonAsync(objectUrl, typeof(MetmuseumObject));

            Art art = new();
            art.ImageUrl = metmuseumObject.ImageUrl;
            art.Title = metmuseumObject.Title;
            art.Date = Capitalize(metmuseumObject.Date);
            art.Author = GetAuthor(metmuseumObject);
            art.Description = GetDescription(metmuseumObject);
            art.SourceUrl = metmuseumObject.SourceURL;
            art.SourceUrlText = _config.GetValue<string>("SourceUrlText:Metmuseum");

            return art;
        }

        private string Capitalize(string text)
        {
            return char.ToUpper(text[0]) + text[1..];
        }

        private string? GetAccessionNumberPart(MetmuseumObject metmuseumObject)
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

        private string? GetCreditPart(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.CreditLine.Length == 0 ? null : metmuseumObject.CreditLine;
        }

        private IList<DescriptionGroup>? GetDescription(MetmuseumObject metmuseumObject)
        {
            List<DescriptionGroup> description = new();

            var placeOfOrigin = GetPlaceOfOriginPart(metmuseumObject);
            if (placeOfOrigin != null)
            {
                description.Add(new DescriptionGroup(placeOfOrigin));
            }

            var dimension = GetDimensionPart(metmuseumObject);
            if (dimension != null)
            {
                description.Add(new DescriptionGroup(dimension));
            }

            var medium = GetMediumPart(metmuseumObject);
            if (medium != null)
            {
                if (description.Count == 2)
                {
                    description[1].Parts.Add(medium);
                }
                else if (placeOfOrigin is not null && dimension is null)
                {
                    description.Add(new DescriptionGroup(medium));
                }
                else if (placeOfOrigin is null && dimension is not null)
                {
                    description[0].Parts.Add(medium);
                }
                else
                {
                    description.Add(new DescriptionGroup(medium));
                }
            }

            var accessionNumber = GetAccessionNumberPart(metmuseumObject);
            if (accessionNumber != null)
            {
                if (description.Count == 2)
                {
                    description[1].Parts.Add(accessionNumber);
                }
                else if (placeOfOrigin is not null && description.Count == 1)
                {
                    description.Add(new DescriptionGroup(accessionNumber));
                }
                else if (placeOfOrigin is null && description.Count == 1)
                {
                    description[0].Parts.Add(accessionNumber);
                }
                else
                {
                    description.Add(new DescriptionGroup(accessionNumber));
                }
            }

            var credit = GetCreditPart(metmuseumObject);
            if (credit != null)
            {
                description.Add(new DescriptionGroup(credit));
            }

            return description;
        }

        private IList<string>? GetDimensionPart(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.Dimensions.Length == 0 ? null : new List<string>() { $"Dimensions: {metmuseumObject.Dimensions}" };
        }

        private string? GetMediumPart(MetmuseumObject metmuseumObject)
        {
            return metmuseumObject.Medium == "" ? null : $"Materials: {metmuseumObject.Medium}";
        }

        private List<string>? GetPlaceOfOriginPart(MetmuseumObject metmuseumObject)
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