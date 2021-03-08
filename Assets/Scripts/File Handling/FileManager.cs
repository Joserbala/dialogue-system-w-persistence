using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Joserbala.Utils;

namespace Joserbala.Serialization
{
    public class FileManager : Singleton<FileManager>
    {

        [SerializeField] private int randomFilesNumber = 100;

        public static string ArchivePath { get; private set; }
        public static string CommandsPath { get; private set; }
        public static string DossiersPath { get; private set; }
        public static string AIFilesPath { get; private set; }
        public static string SavePath { get; private set; }

        private const string LOREM_IPSUMS_DIRECTORY = "LoremIpsums";
        private const string LOREM_IPSUM_FILE = "LoremIpsum";
        private const string TXT_EXTENSION = ".txt";

        private void Awake()
        {
            SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JOSERAIGAME");
            ArchivePath = Path.Combine(SavePath, "Archive");
            DossiersPath = Path.Combine(SavePath, "Dossiers");
            CommandsPath = Path.Combine(SavePath, "Commands");
            AIFilesPath = Path.Combine(SavePath, "ArtificialIntelligenceFiles");

            if (!Directory.Exists(SavePath))
            {
                CreateDirectories();
                CreateRandomFiles(randomFilesNumber, AIFilesPath);
            }
        }

        /// <summary>
        /// Creates all the directories for the game.
        /// </summary>
        private void CreateDirectories()
        {
            Directory.CreateDirectory(SavePath);
            Directory.CreateDirectory(ArchivePath);
            Directory.CreateDirectory(DossiersPath);
            Directory.CreateDirectory(AIFilesPath);
            Directory.CreateDirectory(CommandsPath);
        }

        /// <summary>
        /// Creates <paramref name="filesNumber"/> random binary files with Lorem Ipsum content at <paramref name="path"/>.
        /// </summary>
        /// <param name="filesNumber">The number of files to be created.</param>
        /// <param name="path">The path where <paramref name="filesNumber"/> files will be created.</param>
        public void CreateRandomFiles(int filesNumber, string path)
        {
            string loremIpsumPath;
            string loremIpsumContent;

            for (int i = 0; i < filesNumber; i++)
            {
                loremIpsumPath = Path.Combine(Application.streamingAssetsPath, LOREM_IPSUMS_DIRECTORY, LOREM_IPSUM_FILE + UnityEngine.Random.Range(1, 6) + TXT_EXTENSION);

                loremIpsumContent = Read(loremIpsumPath);

                // Create a file with Lorem Ipsum dummy text.
                SerializerManager.Instance.WriteBinary(Path.Combine(path, Path.GetRandomFileName()), loremIpsumContent);
            }
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

        #endregion

        #region Stream

        public void Write(string path, string text)
        {
            using (var writer = new StreamWriter(path, false))
            {
                writer.WriteLine(text);

                writer.Close();
            }
        }

        #endregion

        public int CountFilesInDirectory(string path)
        {
            IEnumerable files = Directory.EnumerateFiles(path);
            int counter = 0;
            foreach (var item in files)
            {
                counter++;
            }

            return counter;
        }
    }
}