﻿using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    /// <inheritdoc cref="ITretyakovService"/>
    public class TretyakovService : ITretyakovService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TretyakovService> _logger;
        private readonly IHTMLService _htmlService;

        public TretyakovService(IHTMLService htmlService, IConfiguration config, ILogger<TretyakovService> logger)
        {
            _config = config;
            _htmlService = htmlService;
            _logger = logger;
        }

        public async Task<Art?> GetArt()
        {
            try
            {
                string objectUrl = await GetSourceUrl();
                object htmlDocument = await _htmlService.GetHTMLDocument(objectUrl);

                Art art = new();
                art.Description = GetDescription(htmlDocument);
                art.Title = GetTitle(htmlDocument);
                art.Author = GetAuthor(htmlDocument);
                art.Date = GetDate(htmlDocument);

                var medium = GetMeduim(htmlDocument);
                art.AccessNumber = medium?.LastOrDefault();
                medium?.RemoveAt(medium.Count - 1);
                art.Medium = medium;

                art.WayToGet = GetWayToGet(htmlDocument);
                art.ImageUrl = GetImageUrl(htmlDocument);
                art.SourceUrl = objectUrl;
                art.SourceUrlText = _config.GetValue<string>("SourceUrlText:Tretyakov");

                return art;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on Tretyakov art receiving.");
                return null;
            }
        }

        private IList<string>? GetWayToGet(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtSource");
            return GetPart(htmlDocument, selector);
        }

        private IList<string>? GetAuthor(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtAuthor");
            return GetPart(htmlDocument, selector);
        }

        private string? GetDate(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtName");
            if (!_htmlService.IsNodeExists(htmlDocument, selector))
            {
                return null;
            }

            return _htmlService.NormalizeNodeInnerText(_htmlService.GetNodesInnerText(htmlDocument, selector)[1]);
        }

        private IList<string>? GetDescription(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtDesciption");
            var description = GetPart(htmlDocument, selector);

            if (description?.Count == 0)
            {
                return null;
            }

            return description;
        }

        private string GetGalleryUrl()
        {
            string url = _config.GetValue<string>("URL:Tretyakov:Gallery");
            int end = _config.GetValue<int>("ObjectsNumber:Tretyakov:Gallery") + 1;
            return url + new Random().Next(1, end);
        }

        private string GetImageUrl(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtImage");
            return _htmlService.GetAttributeValue(htmlDocument, selector, "src");
        }

        private IList<string>? GetMeduim(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtMedium");
            return GetPart(htmlDocument, selector);
        }

        private IList<string>? GetPart(object htmlDocument, string selector)
        {
            if (!_htmlService.IsNodeExists(htmlDocument, selector))
            {
                return null;
            }

            return _htmlService.NormalizeNodesInnerText(_htmlService.GetNodesInnerText(htmlDocument, selector));
        }

        private async Task<string> GetSourceUrl()
        {
            int end = _config.GetValue<int>("ObjectsNumber:Tretyakov:Art") + 1;
            string selector = _config.GetValue<string>("Selector:Tretyakov:GalleryObject").Replace("{number}", new Random().Next(1, end).ToString());

            object htmlDocument = await _htmlService.GetHTMLDocument(GetGalleryUrl());
            string href = _htmlService.GetAttributeValue(htmlDocument, selector, "href");

            return _config.GetValue<string>("URL:Tretyakov:Base") + href;
        }

        private string GetTitle(object htmlDocument)
        {
            string selector = _config.GetValue<string>("Selector:Tretyakov:ArtName");
            return _htmlService.NormalizeNodeInnerText(_htmlService.GetNodesInnerText(htmlDocument, selector)[0]);
        }
    }
}