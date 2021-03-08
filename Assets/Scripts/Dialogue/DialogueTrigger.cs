using UnityEngine;

namespace Joserbala.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {

        public string[] dialogue;

        public void TriggerDialogue()
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }
}