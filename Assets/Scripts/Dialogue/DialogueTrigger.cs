using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joserbala.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {

        public Dialogue dialogue;

        public void TriggerDialogue()
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }
}