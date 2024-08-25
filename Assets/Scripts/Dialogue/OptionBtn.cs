using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public void ChooseOption(int index)
    {
        DialogueManager.Instance.SetIndexAfterOption(index);
    }
}
