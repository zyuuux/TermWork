using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool inInvestigate;
    public bool canPick;

    public virtual void OnInteract()
    {
        Debug.Log("���������Ʒ��" + name);
    }
}
