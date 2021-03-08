using System.IO;
using System.Xml;
using UnityEngine;
using Joserbala.Utils;
using Joserbala.Data;

namespace Joserbala.Serialization
{
    public class SerializerManager : Singleton<SerializerManager> // TODO: remove unused methods
    {

        // public PlayerData myPlayer;

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

        // public PlayerData DeserializeBinary(string file)
        // {
        //     // Abrir el archivo
        //     var fs = new FileStream(file, FileMode.Open);

        //     // Declarar el serializador
        //     var formatter = new BinaryFormatter();

        //     // Deserializar el fichero
        //     PlayerData playerData = (PlayerData)formatter.Deserialize(fs);

        //     // Cerrar
        //     fs.Close();

        //     return playerData;
        // }

        #endregion

        #region XML

        // public void SerializeXML(PlayerData playerData)
        // {
        //     // Abrir el archivo
        //     var writer = new StreamWriter("PlayerData.xml");

        //     // Declarar el serializador
        //     var serializer = new XmlSerializer(typeof(PlayerData));

        //     // Serializar los datos en el fichero
        //     serializer.Serialize(writer, playerData);

        //     // Cerrar el archivo
        //     writer.Close();
        // }

        // public PlayerData DeserializeXML(string file)
        // {
        //     // Abrir el archivo
        //     var fs = new FileStream(file, FileMode.Open);

        //     // Declarar el serializador
        //     var serializer = new XmlSerializer(typeof(PlayerData));

        //     // Deserializar el fichero
        //     PlayerData playerData = (PlayerData)serializer.Deserialize(fs);

        //     // Cerrar
        //     fs.Close();

        //     playerData.GenerateInternalData();

        //     return playerData;
        // }

        #endregion

        #region JSON

        public void SerializeJSON(string path, DummyData data)
        {
            if (!File.Exists(path))
            {
                var writer = new StreamWriter(path);

                string dataJSON = JsonUtility.ToJson(data);

                writer.Write(dataJSON);

                writer.Close();

                Debug.Log(dataJSON);
            }
        }

        public DummyData DeserializeJSON(string path)
        {
            DummyData jsonData = null;

            if (File.Exists(path))
            {
                var reader = new StreamReader(path);

                jsonData = JsonUtility.FromJson<DummyData>(reader.ReadToEnd());

                // JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), playerData);

                reader.Close();
            }

            return jsonData;
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
    }
}