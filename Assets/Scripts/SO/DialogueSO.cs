using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Scriptables/Dialogue")]
public class DialogueSO : ScriptableObject
{

    public string[] Sentences { get; private set; }
}
