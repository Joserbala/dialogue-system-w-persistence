using System.Xml;

namespace Joserbala.DialogueSystem
{
    public class DialogueXMLNavigator
    {

        /// <summary>
        /// Returns the content nodes of <paramref name="document"/> with the Attribute <paramref name="language"/>.
        /// </summary>
        /// <param name="document">The XML Document to be iterated.</param>
        /// <param name="language">The language of the dialogue to be returned. Right now English ("eng") is the only one supported.</param>
        /// <returns>The content nodes from <paramref name="document"/> with the Attribute <paramref name="language"/>.</returns>
        public static string[] GetContents(XmlDocument document, string language = "eng")
        {
            XmlNodeList dialogueNodes = document.GetElementsByTagName("fragment");
            string[] contents = new string[dialogueNodes.Count];

            if (dialogueNodes != null)
            {
                foreach (XmlNode node in dialogueNodes)
                {
                    int i = 0;
                    foreach (XmlNode childNode in node)
                    {
                        if (childNode.Attributes["lang"]?.InnerText == language)
                        {
                            contents[i] = childNode.InnerText;
                            UnityEngine.Debug.Log(contents[i]);
                        }
                        i++;
                    }
                }
            }

            return contents;
        }
    }
}