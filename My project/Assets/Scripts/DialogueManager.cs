using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Transform dialogueBar;
    public Transform dialogueOption;

    private DialogueObject dialogueObj;
    private Text dialogueName;
    private Text dialogueContent;
    private int index;
    private bool isOption;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueObj != null && !isOption)
        {
            //对话播放完，关闭对话
            if (index == dialogueObj.dialogueNodes.Length || dialogueObj.dialogueNodes[index].isEnd)
            {
                dialogueObj = null;
                dialogueBar.gameObject.SetActive(false);
                index = 0;
            }
            else
            {
                //开始对话
                PlayDialogue();
            }
        }
    }

    public void SetDialogue(DialogueObject dialogue)
    {
        dialogueObj = dialogue;
        dialogueName = dialogueBar.Find("Character").GetComponent<Text>();
        dialogueContent = dialogueBar.Find("Content").GetComponent<Text>();
    }

    public void SetIndexAfterOption(int i)
    {
        index = dialogueObj.dialogueNodes[index-1].options[i].target;
        PlayDialogue();
    }

    public void PlayDialogue()
    {
        DialogueNode node = dialogueObj.dialogueNodes[index++];

        dialogueName.text = node.name;
        dialogueContent.text = node.content;

        dialogueBar.gameObject.SetActive(true);

        if (node.options != null && node.options.Length != 0) 
        {
            dialogueOption.gameObject.SetActive(true);
            dialogueOption.Find("Option1").GetComponentInChildren<Text>().text = node.options[0].content;
            dialogueOption.Find("Option2").GetComponentInChildren<Text>().text = node.options[1].content;
            isOption = true;
        }
        else
        {
            dialogueOption.gameObject.SetActive(false);
            isOption = false;
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

