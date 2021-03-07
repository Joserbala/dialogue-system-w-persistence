using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Joserbala.Utils;
using Joserbala.DialogueSystem;

namespace Joserbala.Serialization
{
    public class FileManager : Singleton<FileManager>
    {

        public string Key;
        public string Password;

        [SerializeField] private int randomFilesNumber = 100;

        public string DesktopPath { get; private set; }
        public string DocumentsPath { get; private set; }
        public string FilesPath { get; private set; }
        public string SavePath { get; private set; }

        private const string LOREM_IPSUM_DIRECTORY = "LoremIpsums";
        private const string LOREM_IPSUM_FILE = "LoremIpsum";
        private const string TXT_EXTENSION = ".txt";

        // private static FileManager instance;

        // public static FileManager Instance { get => instance; }

        // private void Awake()
        // {
        //     if (instance == null)
        //     {
        //         instance = this;
        //     }
        // }

        private void Awake()
        {
            SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JOSERAIGAME");
            DesktopPath = Path.Combine(SavePath, "Desktop");
            DocumentsPath = Path.Combine(SavePath, "Documents");
            FilesPath = Path.Combine(SavePath, "ArtificialIntelligenceFiles");

            if (!Directory.Exists(SavePath))
            {
                CreateDirectories();
                CreateRandomFiles(randomFilesNumber, FilesPath);
            }

            IEnumerable files = Directory.EnumerateFiles(FilesPath);

            int counter = 0;
            foreach (var item in files)
            {
                counter++;
            }

            SerializerManager.Instance.NavigateXML2(DialogueDatabase.Load("Dialogue1.xml"), "eng");
        }

        /// <summary>
        /// Creates all the directories for the game.
        /// </summary>
        private void CreateDirectories()
        {
            Directory.CreateDirectory(SavePath);
            Directory.CreateDirectory(DesktopPath);
            Directory.CreateDirectory(DocumentsPath);
            Directory.CreateDirectory(FilesPath);
        }

        /// <summary>
        /// Creates <paramref name="filesNumber"/> files in <paramref name="path"/>.
        /// </summary>
        /// <param name="filesNumber">The number of files to be created.</param>
        /// <param name="path">The path where <paramref name="filesNumber"/> files will be created.</param>
        private void CreateRandomFiles(int filesNumber, string path)
        {
            string loremIpsumPath;
            string loremIpsumContent;

            for (int i = 0; i < filesNumber; i++)
            {
                loremIpsumPath = Path.Combine(Application.streamingAssetsPath, LOREM_IPSUM_DIRECTORY, LOREM_IPSUM_FILE + UnityEngine.Random.Range(1, 6) + TXT_EXTENSION);

                loremIpsumContent = Read(loremIpsumPath);

                SerializerManager.Instance.WriteBinary(Path.Combine(path, Path.GetRandomFileName()), loremIpsumContent);
            }
        }

        private void Start()
        {
            // CreateKey(Key, Password);
            // Debug.Log(ReadKey(Key));

            // Write(Key, Password);
            // SlowReading(Key);
        }

        #region File

        /// <summary>
        /// Returns the content of the file in <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path where the file to be read is stored.</param>
        /// <returns>The content of the file in <paramref name="path"/>.</returns>
        public string Read(string path)
        {
            string content = string.Empty;

            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }

            return content;
        }

        public string ReadFirstLine(string keyID)
        {
            string file = GenerateFilePath(keyID);
            string[] content;
            string line = string.Empty;

            if (File.Exists(file))
            {
                content = File.ReadAllLines(file);
                line = content.Length > 0 ? content[0] : string.Empty;
            }

            return line;
        }

        #endregion

        #region Stream

        public void Write(string file, string text)
        {
            using (var writer = new StreamWriter(GenerateFilePath(file), true)) // using se encarga de hacer uso de Dispose, liberar memoria si ocurre una excepción
            {
                writer.WriteLine(text);

                writer.Close();
            }
        }

        public void SlowReading(string fileName)
        {
            StartCoroutine(ReadFileSlowCoroutine(GenerateFilePath(fileName), 1f));
        }

        IEnumerator ReadFileSlowCoroutine(string filePath, float delay)
        {
            var reader = new StreamReader(filePath);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Debug.Log(line);
                yield return new WaitForSeconds(delay);
            }
        }

        #endregion

        public string GenerateFilePath(string name)
        {
            return Path.Combine(SavePath, name + ".txt");
        }
    }
}