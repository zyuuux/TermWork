using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    [SerializeField]
    List<Interaction> interactions = new List<Interaction>();
    Dictionary<string, Interaction> interactionDic = new Dictionary<string, Interaction>();

    public void AddInteraction(string name, Interaction interaction)
    {
        if (!interactionDic.ContainsKey(name))
        {
            interactionDic.Add(name, interaction);
            interactions.Add(interaction);
        }
        else
        {
            Debug.Log(name + "已存在");
        }          
    }

    public void RemoveInteraction(string name, Interaction interaction)
    {
        if (interactionDic.ContainsKey(name))
        {
            interactionDic.Remove(name);
            interactions.Remove(interaction);
        }
        else
        {
            Debug.Log(name + "不存在");
        }
    }

    public bool isExistInteraction(string name)
    {
        return interactionDic.ContainsKey(name);
    }
}
