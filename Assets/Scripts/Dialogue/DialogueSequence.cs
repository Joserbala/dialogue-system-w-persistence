using UnityEngine;

namespace Joserbala.DialogueSystem
{
	public class DialogueSequence : MonoBehaviour
	{
		private int currentDialogue = 0;

		public void DialogueStart()
		{
			var dialogues = DialogueRepository.ObtainDialogue(currentDialogue);
			DialogueManager.Instance.StartDialogue(dialogues);

			currentDialogue++;
		}
	}
}