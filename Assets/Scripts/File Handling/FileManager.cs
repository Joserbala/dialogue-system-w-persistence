using System.Collections;
using System.IO;
using UnityEngine;
using Utils;

public class FileManager : Singleton<FileManager>
{
    public string Key;
    public string Password;

    public string SavePath = "C:\\Users\\joseg\\UnityTest";

    // private static FileManager instance;

    // public static FileManager Instance { get => instance; }

    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    // }

    private void Start()
    {
        // CreateKey(Key, Password);
        // Debug.Log(ReadKey(Key));

        // Write(Key, Password);
        // SlowReading(Key);
    }

    #region File

    // public void Write(string pathFile, string text) // TODO: buscar crear esta clase más general, con un KeyManager
    // {

    // }

    // public string Read(string pathFile)
    // {
    //     return string.Empty;
    // }

    public void CreateKey(string keyID, string keyPassword)
    {
        string file = GenerateFilePath(keyID);

        if (!File.Exists(file))
        {
            File.WriteAllText(file, Key + ":" + keyPassword);
        }
    }

    public string ReadKey(string keyID)
    {
        string file = GenerateFilePath(keyID);
        string content = string.Empty;

        if (File.Exists(file))
        {
            content = File.ReadAllText(file);
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
            line = (content.Length > 0 ? content[0] : string.Empty);
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
        return SavePath + "\\" + name + ".txt";
    }
}
