using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelop : Interaction
{
    public GameObject envelopPanel;
    bool isPerform = false;

    protected override void Perform()
    {
        if (isPerform)
        {
            isPerform = false;
            gameObject.SetActive(false);
            envelopPanel.SetActive(true);
        }
    }

    protected override void DoublePerform()
    {
        transform.GetComponent<SpriteRenderer>().sortingLayerName = "Interation";
        transform.GetComponent<Animator>().SetBool("Perform", true);
        isPerform = true;
    }
}
