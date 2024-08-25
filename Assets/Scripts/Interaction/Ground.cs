using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Interaction
{
    public GameObject key;

    public override void OnInteract()
    {
        base.OnInteract();

        isInteractable = false;
    }

    protected override void Perform()
    {
        key.SetActive(true);
    }
}
