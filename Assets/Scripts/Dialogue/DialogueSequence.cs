using System.Xml;
using UnityEngine;

namespace Joserbala.DialogueSystem
{
    public class DialogueSequence : MonoBehaviour
    {
        private int currentDialogue = 0;

        private const string DIALOGUE_FILE = "Dialogue";
        private const string XML_EXTENSION = ".xml";

        public void DialogueStart()
        {
            string[] dialogue = ObtainNextDialogue();
            foreach (var item in dialogue)
            {
                Debug.Log("Inside DialogueSequence: " + item);
            }
            DialogueManager.Instance.StartDialogue(dialogue);
        }

        private string[] ObtainNextDialogue()
        {
            currentDialogue++;

            XmlDocument doc = DialogueDatabase.Load(DIALOGUE_FILE + currentDialogue + XML_EXTENSION);

            return DialogueXMLNavigator.GetContents(doc);
        }
    }
}