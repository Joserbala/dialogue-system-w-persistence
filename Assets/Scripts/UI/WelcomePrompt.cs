using UnityEngine;
using TMPro;
using Joserbala.Serialization;

namespace Joserbala.UI
{
    public class WelcomePrompt : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI initialText;

        private void Start()
        {
            initialText.text = "This game makes use of your MyDocuments folder.\n\nYou can find this folder at " + FileManager.SavePath + ".";
        }
    }
}