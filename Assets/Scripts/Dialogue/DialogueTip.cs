using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTip : MonoBehaviour
{
    public Sprite unfinishedDialogue;
    public Sprite finishDialogue;
    public DialogueObject m_dialogue;

    private void OnEnable()
    {
        transform.GetComponent<SpriteRenderer>().enabled = false;
        EventHandler.DialogueBeginEvent += OnDialogueBegin;
    }

    private void OnDisable()
    {
        EventHandler.DialogueBeginEvent -= OnDialogueBegin;
    }

    public void SetDialogue(DialogueObject dialogue)
    {
        transform.GetComponent<SpriteRenderer>().sprite = unfinishedDialogue;
        m_dialogue = dialogue;
    }

    public DialogueObject GetDialogue()
    {
        return m_dialogue;
    }

    private void OnDialogueBegin(bool isRefreshTip)
    {
        if (isRefreshTip)
        {
            transform.GetComponent<SpriteRenderer>().sprite = finishDialogue;
        }       
    }
}
