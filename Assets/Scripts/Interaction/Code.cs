using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : Interaction
{
    public GameObject code_Mag;

    protected override void Perform()
    {
        bool isActive = code_Mag.activeSelf;
        code_Mag.SetActive(!isActive);
    }
}
