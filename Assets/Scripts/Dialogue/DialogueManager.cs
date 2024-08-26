using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public List<DialogueObject> dialogues;
    public Transform dialogueBar;
    public Transform dialogueOption;

    private DialogueObject curDialogue;
    private Text dialogueName;
    private Text dialogueContent;
    private int index;
    private bool isEnd;

    public void SetDialogue(DialogueObject dialogue)
    {
        curDialogue = dialogue;
        dialogueName = dialogueBar.Find("Character").GetComponent<Text>();
        dialogueContent = dialogueBar.Find("Content").GetComponent<Text>();
    }

    public void SetIndexAfterOption(int i)
    {
        index = curDialogue.dialogueNodes[index-1].options[i].target;
        PlayDialogue(false);
    }

    public bool CanPlayDialogue()
    {
        return curDialogue != null;
    }

    public void PlayDialogue(bool isRefreshTip)
    {
        if (curDialogue != null)
        {
            if (index == 0)
            {
                EventHandler.CallDialogueBeginEvent(isRefreshTip);
            }

            //对话播放完，关闭对话
            if (index == curDialogue.dialogueNodes.Length || isEnd)
            {
                isEnd = false;
                curDialogue = null;
                dialogueBar.gameObject.SetActive(false);
                index = 0;
                EventHandler.CallDialogueEndEvent();
                return;
            }

            DialogueNode node = curDialogue.dialogueNodes[index++];

            dialogueName.text = node.name;
            dialogueContent.text = node.content;

            dialogueBar.gameObject.SetActive(true);

            if (node.options != null && node.options.Length != 0)
            {
                dialogueOption.gameObject.SetActive(true);
                dialogueOption.Find("Option1").GetComponentInChildren<Text>().text = node.options[0].content;
                dialogueOption.Find("Option2").GetComponentInChildren<Text>().text = node.options[1].content;
            }
            else
            {
                dialogueOption.gameObject.SetActive(false);
            }

            if (node.isEnd)
            {
                isEnd = true;
            }
        }       
    }
}

[Serializable]
public class DialogueNode
{
    [Header("角色的名字")]
    public string name;

    [TextArea, Header("对话的内容")]
    public string content;

    public OptionNode[] options;

    [Header("是否结束对话")]
    public bool isEnd;
}

[Serializable]
public class OptionNode
{
    [Header("选项的内容")]
    public string content;

    public int target;
}

