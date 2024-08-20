using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTip : MonoBehaviour
{
    public Sprite unfinishedDialogue;
    public Sprite finishDialogue;
    public DialogueObject dialogue;
    public DialogueObject newDialogue;

    public void StartDialogue()
    {
        transform.GetComponent<SpriteRenderer>().sprite = finishDialogue;
        DialogueManager.Instance.SetDialogue(dialogue);
    }

    public void ChangeDialogue()
    {
        transform.GetComponent<SpriteRenderer>().sprite = unfinishedDialogue;
        dialogue = newDialogue;
    }
}
