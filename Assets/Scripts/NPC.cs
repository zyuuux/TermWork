using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTip dialogueTip;

    public void SetDialogue()
    {
        dialogueTip.SetDialogue(DialogueManager.Instance.dialogues[0]);
    }
}
