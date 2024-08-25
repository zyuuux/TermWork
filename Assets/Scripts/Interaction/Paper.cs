using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Interaction
{
    public GameObject paperPanel;

    protected override void Perform()
    {
        paperPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
