namespace EverydayIsArtAPI.Services
{
    public interface IHTMLService
    {
        public string GetAttributeValue(object htmlDocument, string nodeSelector, string attributeName);

        public Task<object> GetHTMLDocument(string url);

        public IList<string> GetNodesInnerText(object htmlDocument, string nodeSelector);

        public bool IsNodeExists(object htmlDocument, string nodeSelector);

        public string NormalizeNodeInnerText(string node);

        public IList<string> NormalizeNodesInnerText(IList<string> nodes);
    }
}