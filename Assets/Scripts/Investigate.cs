using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Investigate : Singleton<Investigate>
{
    public Transform room;
    public GameObject[] characters;
    new Camera camera;
    bool isInvestigate = false;

    public bool IsIsInvestigate()
    {
        return isInvestigate;
    }

    private void Start()
    {
        camera = Camera.main;
        camera.GetComponent<WaterWaveEffect>().enabled = false;
        transform.GetComponent<Button>().onClick.AddListener(OnInvisible);
    }

    private void OnInvisible()
    {
        SpriteRenderer[] spriteRenderers = room.GetComponentsInChildren<SpriteRenderer>();

        if (!isInvestigate)
        {
            camera.GetComponent<WaterWaveEffect>().enabled = true;
            isInvestigate = true;
            transform.GetComponentInChildren<Text>().text = "ÖÐ¶Ï";

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.gray;
            }

            foreach (GameObject o in characters)
            {
                o.SetActive(false);
            }
        }
        else
        {
            camera.GetComponent<WaterWaveEffect>().enabled = false;
            isInvestigate = false;
            transform.GetComponentInChildren<Text>().text = "µ÷²é";

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.white;
            }

            foreach (GameObject o in characters)
            {
                o.SetActive(true);
            }
        }
    }
}
