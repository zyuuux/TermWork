using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionName;
    public bool isInteractable = true;

    // 当玩家与物品交互时调用  
    public virtual void OnInteract()
    {
        if (!isInteractable) return;

        Debug.Log("Interact with the" + name);
        Perform();  
    }

    // 双击鼠标事件
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
