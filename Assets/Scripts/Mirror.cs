using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject mirror;
    private bool isActive;

    public void CtrlMirror()
    {
        isActive = !isActive;
        mirror.SetActive(isActive);
    }
}
