using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Joserbala.Utils;
using System;
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

        public void StartDialogue(Dialogue dialogue)
        {
            Debug.Log("Starting conversation");

            sentences.Clear();

            foreach (string sentence in sentences)
            {
                sentences.Enqueue(sentence);
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