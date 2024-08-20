using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : Interaction
{
    public float targetX = -4.0f;

    public override void OnInteract()
    {
        transform.DOMoveX(targetX, 1.5f);
    }
}
