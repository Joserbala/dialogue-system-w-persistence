using System.Collections.Generic;
using UnityEngine;
using Joserbala.Utils;
using TMPro;

namespace Joserbala.DialogueSystem
{
    public class DialogueManager : Singleton<DialogueManager>
    {

        [SerializeField] private TextMeshProUGUI dialogueText;

        private Queue<string> sentences;

        private void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(string[] fragments)
        {
            Debug.Log("Starting conversation");

            sentences.Clear();

            foreach (string fragment in fragments)
            {
                Debug.Log("Inside DialogueManager: " + fragment);
                sentences.Enqueue(fragment);
            }

            DisplayNextSequence();
        }

        public void DisplayNextSequence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }

        private void EndDialogue()
        {
            Debug.Log("End of conversation.");
        }
    }
}