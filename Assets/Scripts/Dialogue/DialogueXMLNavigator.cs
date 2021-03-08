using System.Collections.Generic;
using System.Xml;
using Joserbala.Utils;

namespace Joserbala.DialogueSystem
{
    public class DialogueXMLNavigator
    {

        private const string FRAGMENT_TAG = "fragment";
        private const string LANG_ATTRIBUTE = "lang";

        /// <summary>
        /// Returns the content nodes of <paramref name="document"/> with the Attribute <paramref name="language"/>.
        /// </summary>
        /// <param name="document">The XML Document to be iterated.</param>
        /// <param name="language">The language of the dialogue to be returned. Right now English ("eng") is the only one supported.</param>
        /// <returns>The content nodes from <paramref name="document"/> with the Attribute <paramref name="language"/>.</returns>
        public static string[] GetContents(XmlDocument document, string language = "eng")
        {
            XmlNodeList fragmentNodes = document.GetElementsByTagName(FRAGMENT_TAG);
            string[] contents = new string[fragmentNodes.Count];

            if (fragmentNodes != null)
            {
                int i = 0;
                // Iterate the fragment nodes.
                foreach (XmlNode fragmentNode in fragmentNodes)
                {
                    // Iterate the content nodes.
                    foreach (XmlNode contentNode in fragmentNode)
                    {
                        /// Obtain the content with <see cref="LANG_ATTRIBUTE"/> equal to <paramref name="language"/>.
                        if (contentNode.Attributes[LANG_ATTRIBUTE]?.InnerText == language)
                        {
                            contents[i] = contentNode.InnerText;
                            i++;
                        }
                    }
                }
            }

            contents = StringUtils.TruncateNullOrEmptyValuesArray(contents);

            return contents;
        }
    }
}