using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public GameObject interactionPanel;
    public Transform pick;
    private string interactionName;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

            if (hit && hit.transform.CompareTag("Interaction"))
            {
                Interaction i = hit.transform.GetComponent<Interaction>();
                if (i.inInvestigate == Investigate.Instance.IsIsInvestigate())
                {
                    i.OnInteract();
                    interactionName = i.name;
                    if (i.canPick)
                    {
                        pick = i.transform;
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if ((hit == false || !hit.transform.CompareTag("Interaction")) && interactionPanel.activeInHierarchy)
                {
                    interactionPanel.transform.Find(interactionName).gameObject.SetActive(false);
                    interactionPanel.SetActive(false);
                    interactionName = string.Empty;
                }             
            }
        }
    }
}
