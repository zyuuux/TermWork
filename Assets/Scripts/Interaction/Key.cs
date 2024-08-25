using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interaction
{
    public override void OnInteract()
    {
        base.OnInteract();

        isInteractable = false;
    }

    protected override void Perform()
    {
        InteractionManager.Instance.AddInteraction("Key", this);
        gameObject.SetActive(false);
    }
}
