using System.IO;
using UnityEngine;
using Joserbala.Utils;
using Joserbala.Data;

namespace Joserbala.Serialization
{
    public class SerializerManager : Singleton<SerializerManager>
    {

        #region BINARY

        /// <summary>
        /// Writes <paramref name="content"/> into a file that will be stored in <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The file where <paramref name="content"/> will be stored.</param>
        /// <param name="content">The content that will be stored in <paramref name="path"/>.</param>
        public void WriteBinary(string path, string content)
        {
            using var writer = new BinaryWriter(File.Open(path, FileMode.Create));

            writer.Write(content);
        }

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

                reader.Close();
            }

            return jsonData;
        }

        #endregion
    }
}