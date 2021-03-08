using System.IO;
using UnityEngine;
using Joserbala.Serialization;

namespace Joserbala.Utils
{
    public class ApplicationQuit : MonoBehaviour
    {
        private void OnApplicationQuit()
        {
            Directory.Delete(FileManager.SavePath, true);
        }
    }
}