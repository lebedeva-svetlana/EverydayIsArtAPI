using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace EverydayIsArtAPI.Services
{
    public class HTMLService : IHTMLService
    {
        public string GetAttributeValue(object htmlDocument, string nodeSelector, string attributeName)
        {
            return (htmlDocument as HtmlDocument).DocumentNode.SelectSingleNode(nodeSelector).Attributes[attributeName].Value;
        }

        public async Task<object> GetHTMLDocument(string url)
        {
            HtmlDocument htmlDocument = new HtmlWeb().Load(url);
            return htmlDocument;
        }

        public IList<string> GetNodesInnerText(object htmlDocument, string nodeSelector)
        {
            return GetNodes(htmlDocument, nodeSelector).Select(e => e.InnerText).ToList();
        }

        public bool IsNodeExists(object htmlDocument, string nodeSelector)
        {
            return (htmlDocument as HtmlDocument).DocumentNode.SelectSingleNode(nodeSelector) is not null;
        }

        public string NormalizeNodeInnerText(string node)
        {
            node = node.Replace("\n", "");
            node = Regex.Replace(node, " {2,}", " ");
            node = node.Trim();
            return node;
        }

        public IList<string> NormalizeNodesInnerText(IList<string> nodes)
        {
            for (int i = 0; i < nodes.Count; ++i)
            {
                nodes[i] = NormalizeNodeInnerText(nodes[i]);
            }
            return nodes;
        }

        private HtmlNodeCollection GetNodes(object htmlDocument, string nodeSelector)
        {
            return ((HtmlDocument)htmlDocument).DocumentNode.SelectNodes(nodeSelector);
        }
    }
}