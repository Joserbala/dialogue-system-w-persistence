using System.Collections.Generic;
using Joserbala.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Joserbala.DialogueSystem
{
	public class DialogueManager : Singleton<DialogueManager>
	{
		[SerializeField] private TextMeshProUGUI dialogueText;
		[SerializeField] private UnityEvent whenDialogueStarts;
		[SerializeField] private UnityEvent whenDialogueFinishes;

		private Queue<string> sentences;

		private void Start()
		{
			sentences = new Queue<string>();
		}

		public void StartDialogue(string[] fragments)
		{
			whenDialogueStarts?.Invoke();

			sentences.Clear();

			foreach (string fragment in fragments)
			{
				sentences.Enqueue(fragment);
			}

			DisplayNextSequence();
		}

		public void DisplayNextSequence()
		{
			if (sentences.Count < 2)
			{
				EndDialogue();
			}

			string sentence = sentences.Dequeue();
			dialogueText.text = sentence;
		}

		private void EndDialogue()
		{
			whenDialogueFinishes?.Invoke();
		}
	}
}