using Joserbala.Utils.Enums;
using UnityEngine;

namespace Joserbala.DialogueSystem
{
	public class DialogueSequence : MonoBehaviour
	{
		[SerializeField] private Languages language = Languages.English;

		private int currentDialogue = 1;

		public void DialogueStart()
		{
			var dialogues = DialogueRepository.ObtainDialogue(currentDialogue, language);
			DialogueManager.Instance.StartDialogue(dialogues);

			currentDialogue++;
		}
	}
}