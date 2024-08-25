using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interaction
{
    public DialogueTip tip;
    public bool isTrigger;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnInteract()
    {
        base.OnInteract();

        isInteractable = false;
    }

    protected override void Perform()
    {
        animator.SetTrigger("Hit");

        if (isTrigger)
        {
            tip.SetDialogue(DialogueManager.Instance.dialogues[1]);
            DialogueManager.Instance.SetDialogue(DialogueManager.Instance.dialogues[2]);
            DialogueManager.Instance.PlayDialogue(false);
        }
    }
}
