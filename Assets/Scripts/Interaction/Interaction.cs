using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionName;
    public bool isInteractable = true;

    // ���������Ʒ����ʱ����  
    public virtual void OnInteract()
    {
        if (!isInteractable) return;

        Debug.Log("Interact with the" + name);
        Perform();  
    }

    // ˫������¼�
    public virtual void OnDoubleInteract()
    {
        if (!isInteractable) return;

        Debug.Log("Double Interact with the" + name);
        DoublePerform();
    }

    protected virtual void Perform()
    {
        
    }

    protected virtual void DoublePerform()
    {

    }
}
