using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Paper : Interaction
{
    public GameObject panel;
    public GameObject ui;
    public GameObject ui2;
    public GameObject o;
    public string paperName;
    public DialogueTip tip;

    public override void OnInteract()
    {
        if (CursorManager.Instance.pick != null && CursorManager.Instance.pick.name == "��ʧ��ֽ��")
        {
            paperName = "������ֽ��";
            o.SetActive(true);
            ui = ui2;
            CursorManager.Instance.pick = null;
            tip.ChangeDialogue();
        }

        panel.SetActive(true);
        ui.SetActive(true);
        panel.GetComponentInChildren<Text>().text = paperName;
        if (canPick)
        {
            gameObject.SetActive(false);
        }
    }
}
