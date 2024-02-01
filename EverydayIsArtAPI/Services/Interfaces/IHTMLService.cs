namespace EverydayIsArtAPI.Services
{
    /// <summary>
    ///     A service that can be used to work with HTML document.
    /// </summary>
    public interface IHTMLService
    {
        /// <summary>
        ///     Returns value of a node attribute.
        /// </summary>
        /// <param name="htmlDocument">
        ///     A HTML document.
        /// </param>
        /// <param name="nodeSelector">
        ///     A node selector.
        /// </param>
        /// <param name="attributeName">
        ///     An attribute name.
        /// </param>
        /// <returns>
        ///     A value of node attribute.
        /// </returns>
        public string GetAttributeValue(object htmlDocument, string nodeSelector, string attributeName);

        /// <summary>
        ///     Returns a HTML document from an URL.
        /// </summary>
        /// <param name="url">
        ///     An URL of HTML.
        /// </param>
        /// <returns>
        ///     The HTML document.
        /// </returns>
        public Task<object> GetHTMLDocument(string url);

        /// <summary>
        ///     Returns an inner text of nodes with a specific selector.
        /// </summary>
        /// <param name="htmlDocument">
        ///     A HTML document.
        /// </param>
        /// <param name="nodeSelector">
        ///     A node selector.
        /// </param>
        /// <returns>
        ///     A list that contains the inner text of nodes.
        /// </returns>
        public IList<string> GetNodesInnerText(object htmlDocument, string nodeSelector);

        /// <summary>
        ///     Checks if a node exists.
        /// </summary>
        /// <param name="htmlDocument">
        ///     A HTML document.
        /// </param>
        /// <param name="nodeSelector">
        ///     A node selector.
        /// </param>
        /// <returns>
        ///     True if the node exists; otherwise, false.
        /// </returns>
        public bool IsNodeExists(object htmlDocument, string nodeSelector);

        /// <summary>
        ///     Removes white spaces and new line symbols from an inner text of a node.
        /// </summary>
        /// <param name="node">
        ///     An inner text of a node.
        /// </param>
        /// <returns>
        ///     The normalized inner text of the node.
        /// </returns>
        public string NormalizeNodeInnerText(string node);

        /// <summary>
        ///     Removes white spaces and new line symbols from an inner text of a multiple nodes.
        /// </summary>
        /// <param name="nodes">
        ///     An inner text of a nodes.
        /// </param>
        /// <returns>
        ///     The normalized inner text of the nodes.
        /// </returns>
        public IList<string> NormalizeNodesInnerText(IList<string> nodes);
    }
}