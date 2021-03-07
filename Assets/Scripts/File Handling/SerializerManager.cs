using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Joserbala.Data;
using UnityEngine;
using Joserbala.Utils;

namespace Joserbala.Serialization
{
    public class SerializerManager : Singleton<SerializerManager>
    {

        public PlayerData myPlayer;

        private void Start()
        {
            // PlayerData myPlayer = new PlayerData("Ando", CharacterClass.Warrior);

            // SerializeJSON(myPlayer);

            // myPlayer = DeserializeJSON("PlayerData.json");
            // myPlayer.ShowInternalData();

            // NavigateXML("WeaponsData.xml");
        }

        #region BINARY

        /// <summary>
        /// Writes <paramref name="content"/> into a file that will be stored in <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The file where <paramref name="content"/> will be stored.</param>
        /// <param name="content">The content that will be stored in <paramref name="path"/>.</param>
        public void WriteBinary(string path, string content)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(content);
            }
        }

        public PlayerData DeserializeBinary(string file)
        {
            // Abrir el archivo
            var fs = new FileStream(file, FileMode.Open);

            // Declarar el serializador
            var formatter = new BinaryFormatter();

            // Deserializar el fichero
            PlayerData playerData = (PlayerData)formatter.Deserialize(fs);

            // Cerrar
            fs.Close();

            return playerData;
        }

        #endregion

        #region XML

        public void SerializeXML(PlayerData playerData)
        {
            // Abrir el archivo
            var writer = new StreamWriter("PlayerData.xml");

            // Declarar el serializador
            var serializer = new XmlSerializer(typeof(PlayerData));

            // Serializar los datos en el fichero
            serializer.Serialize(writer, playerData);

            // Cerrar el archivo
            writer.Close();
        }

        public PlayerData DeserializeXML(string file)
        {
            // Abrir el archivo
            var fs = new FileStream(file, FileMode.Open);

            // Declarar el serializador
            var serializer = new XmlSerializer(typeof(PlayerData));

            // Deserializar el fichero
            PlayerData playerData = (PlayerData)serializer.Deserialize(fs);

            // Cerrar
            fs.Close();

            playerData.GenerateInternalData();

            return playerData;
        }

        #endregion

        #region JSON

        public void SerializeJSON(PlayerData playerData)
        {
            // Abrir el archivo
            var writer = new StreamWriter("PlayerData.json");

            // Serializar
            string playerJSON = JsonUtility.ToJson(playerData);

            // Serlizar los datos en el fichero
            writer.Write(playerJSON);

            // Cerrar el archivo
            writer.Close();

            Debug.Log(playerJSON);
        }

        public PlayerData DeserializeJSON(string file)
        {
            // Abrir el archivo
            var reader = new StreamReader(file);

            // Deserializar el fichero
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(reader.ReadToEnd());

            // JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), playerData);

            // Cerrar
            reader.Close();

            return playerData;
        }

        #endregion

        public void NavigateXML(string file)
        {
            var doc = new XmlDocument();
            doc.Load(file);

            XmlNodeList nameNodes = doc.DocumentElement.SelectNodes("//Name");

            if (nameNodes != null)
            {
                foreach (XmlNode node in nameNodes)
                {
                    Debug.Log(node.Name + ":" + node.InnerText);
                }
            }

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string name = node.Name;
                string text = node.InnerText;
                string value = node.ChildNodes[0].InnerText;
                string attr = node.Attributes["rarity"]?.InnerText;

                Debug.Log(name + " : " + value + " - " + attr + "[" + text + "]");
            }
        }

        public string[] NavigateXML2(XmlDocument document, string language)
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
                            Debug.Log(contents[i]);
                        }
                        i++;
                    }
                }
            }

            return contents;
        }
    }
}