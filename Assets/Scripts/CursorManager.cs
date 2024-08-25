using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public List<GameObject> UIPanels;
    private float clickTime;

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

                if ((Time.realtimeSinceStartup - clickTime) < 0.2f)
                {
                    i.OnDoubleInteract();
                }
                else
                {
                    i.OnInteract();
                    clickTime = Time.realtimeSinceStartup;
                }                  
            }
            else
            {
                foreach (GameObject p in UIPanels)
                {
                    if (p != null)
                    {
                        p.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
