using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interaction
{
    public GameObject item;

    public override void OnInteract()
    {
        base.OnInteract();

        isInteractable = false;
    }

    protected override void Perform()
    {
        if (InteractionManager.Instance.isExistInteraction("Key"))
        {
            item.SetActive(true);
        }      
    }
}
