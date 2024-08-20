using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "创建对话", fileName = "对话")]
public class DialogueObject : ScriptableObject
{
    public DialogueNode[] dialogueNodes;
}
