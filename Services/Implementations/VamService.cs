using EverydayIsArtAPI.Data.VamGallery;
using EverydayIsArtAPI.Data.VamObject;
using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    public class VamService : IVamService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient = new();

        public VamService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Art> GetArt()
        {
            string objectUrl = await GetSourceUrl();
            VamObject? vamObject = (VamObject?)await _httpClient.GetFromJsonAsync(objectUrl, typeof(VamObject));

            Art art = new();
            art.ImageUrl = _config.GetValue<string>("URL:Vam:ImageUrl").Replace("{ObjectNumber}", vamObject.Record.ImagesNumbers[0]);
            art.Title = GetTitle(vamObject);
            art.Date = GetDate(vamObject);
            art.Author = GetAuthor(vamObject);
            art.Description = GetDescription(vamObject);
            art.SourceUrl = _config.GetValue<string>("URL:Vam:Art") + vamObject.Record.SystemNumber;
            art.SourceUrlText = _config.GetValue<string>("SourceUrlText:Vam");

            return art;
        }

        private string Capitalize(string text)
        {
            return char.ToUpper(text[0]) + text[1..];
        }

        private string? GetAccessionNumberPart(VamObject vamObject)
        {
            if (vamObject.Record.AccessionNumber is null)
            {
                return null;
            }

            return $"Accession number: {vamObject.Record.AccessionNumber}";
        }

        private List<string>? GetAuthor(VamObject vamObject)
        {
            if (vamObject.Record.Artists is null || vamObject.Record.Artists.Length == 0)
            {
                return null;
            }

            List<string>? authors = new();

            for (int i = 0; i < vamObject.Record.Artists.Length; ++i)
            {
                string author = vamObject.Record.Artists[i].Name.Text;
                if (author.ToLower() == "unknown")
                {
                    author = $"{Capitalize(author)} artist";
                }
                if (vamObject.Record.Artists[i].Association.Text != "")
                {
                    author = $"{author} ({vamObject.Record.Artists[i].Association.Text})";
                }
                authors.Add(author);
            }

            return authors;
        }

        private string? GetBriefDescriptionPart(VamObject vamObject)
        {
            if (vamObject.Record.BriefDescription is null || vamObject.Record.BriefDescription == "")
            {
                return null;
            }

            return $"Brief description: {vamObject.Record.BriefDescription}";
        }

        private string? GetCreditPart(VamObject vamObject)
        {
            return vamObject.Record.CreditLine is null ? null : vamObject.Record.CreditLine;
        }

        private string? GetDate(VamObject vamObject)
        {
            string? date = null;

            if (vamObject.Record.ProductionDates is not null && vamObject.Record.ProductionDates.Length != 0)
            {
                date = vamObject.Record.ProductionDates[0].Date.Text;
                if (vamObject.Record.ProductionDates[0].Association.Text != "")
                {
                    date = $"{date} ({vamObject.Record.ProductionDates[0].Association.Text})";
                }
            }

            if (date is not null)
            {
                date = Capitalize(date);
            }

            return date;
        }

        private IList<DescriptionGroup>? GetDescription(VamObject vamObject)
        {
            List<DescriptionGroup> description = new();

            var placeOfOrigin = GetPlaceOfOriginPart(vamObject);
            if (placeOfOrigin != null)
            {
                description.Add(new DescriptionGroup(placeOfOrigin));
            }

            var dimension = GetDimensionPart(vamObject);
            if (dimension != null)
            {
                description.Add(new DescriptionGroup(dimension));
            }

            var medium = GetMediumPart(vamObject);
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

            var accessionNumber = GetAccessionNumberPart(vamObject);
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

            var credit = GetCreditPart(vamObject);
            if (credit != null)
            {
                description.Add(new DescriptionGroup(credit));
            }

            var briefDescription = GetBriefDescriptionPart(vamObject);
            if (briefDescription != null)
            {
                description.Add(new DescriptionGroup(briefDescription));
            }

            var summary = GetSummaryPart(vamObject);
            if (summary != null)
            {
                for (int i = 0; i < summary.Count; ++i)
                {
                    description.Add(new DescriptionGroup(summary[i]));
                }
            }

            return description;
        }

        private IList<string>? GetDimensionPart(VamObject vamObject)
        {
            if (vamObject.Record.Dimensions is null || vamObject.Record.Dimensions.Length == 0)
            {
                return null;
            }

            List<string>? dimesions = new();

            for (int i = 0; i < vamObject.Record.Dimensions.Length; ++i)
            {
                if (vamObject.Record.Dimensions[i].ObjectDimension == "")
                {
                    continue;
                }

                string dimesion = $"{vamObject.Record.Dimensions[i].ObjectDimension}: {vamObject.Record.Dimensions[i].Value}{vamObject.Record.Dimensions[i].Unit}";

                if (vamObject.Record.Dimensions[i].Part != "")
                {
                    string part = vamObject.Record.Dimensions[i].Part;
                    part = Capitalize(part);
                    dimesion = $"{part} {char.ToLower(dimesion[0])}{dimesion[1..]}";
                }

                if (vamObject.Record.Dimensions[i].Note != "")
                {
                    dimesion = $"{dimesion} ({vamObject.Record.Dimensions[i].Note})";
                }

                dimesions.Add(dimesion);
            }

            return dimesions;
        }

        private string GetGalleryUrl()
        {
            string url = _config.GetValue<string>("URL:Vam:GalleryJson");
            int end = _config.GetValue<int>("ObjectsNumber:Vam:Gallery") + 1;
            return url + new Random().Next(1, end);
        }

        private string? GetMediumPart(VamObject vamObject)
        {
            return vamObject.Record.Materials == "" ? null : $"Materials and techniques: {vamObject.Record.Materials}";
        }

        private List<string>? GetPlaceOfOriginPart(VamObject vamObject)
        {
            if (vamObject.Record.PlacesOfOrigin is null || vamObject.Record.PlacesOfOrigin.Length == 0)
            {
                return null;
            }

            List<string>? places = new();

            for (int i = 0; i < vamObject.Record.PlacesOfOrigin.Length; ++i)
            {
                string place = vamObject.Record.PlacesOfOrigin[i].Place.Text;
                if (vamObject.Record.PlacesOfOrigin[i].Association.Text != "")
                {
                    place = $"{place} ({vamObject.Record.PlacesOfOrigin[i].Association.Text})";
                }
                places.Add(place);
            }

            return places;
        }

        private async Task<string> GetSourceUrl()
        {
            VamGallery? gallery = (VamGallery?)await _httpClient.GetFromJsonAsync(GetGalleryUrl(), typeof(VamGallery));
            int end = _config.GetValue<int>("ObjectsNumber:Vam:Art");
            string objectNumber = gallery.Objects[new Random().Next(0, end)].ObjectNumber;
            return _config.GetValue<string>("URL:Vam:ArtJson") + objectNumber;
        }

        private List<string>? GetSummaryPart(VamObject vamObject)
        {
            if (vamObject.Record.Summary is null)
            {
                return null;
            }

            string separator;
            if (vamObject.Record.Summary.Contains('\r'))
            {
                separator = "\r\n\r\n";
            }
            else
            {
                separator = "\n\n";
            }

            return RemoveTags(vamObject.Record.Summary).Split(separator).ToList();
        }

        private string? GetTitle(VamObject vamObject)
        {
            string? title = null;

            if (vamObject.Record.Titles is not null && vamObject.Record.Titles.Length != 0)
            {
                title = vamObject.Record.Titles[0].ObjectTitle;
            }
            else if (vamObject.Record.PartTypes is not null && vamObject.Record.PartTypes.Length != 0 && vamObject.Record.PartTypes[0].Length != 0)
            {
                title = vamObject.Record.PartTypes[0][0].Text;
            }

            if (title is not null)
            {
                title = Capitalize(title);
            }

            return title;
        }

        private string RemoveTags(string text)
        {
            return text.Replace("<i>", "").Replace("</i>", "");
        }
    }
}