using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 0.05f;

    Animator animator;
    SpriteRenderer[] spriteRenderers;
    bool isFlip;
    bool canTalk;
    Transform talker;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        PlayerWalk();

        if (Input.GetKeyDown(KeyCode.E) && canTalk)
        {
            talker.GetComponent<DialogueTip>().StartDialogue();
        }
    }

    private void PlayerWalk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("IsWalk", true);
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal;
            position.y = position.y + speed * vertical;

            transform.position = position;
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        if (horizontal < 0)
        {
            isFlip = true;
            foreach (var renderer in spriteRenderers)
            {
                renderer.flipX = isFlip;
            }
        }
        else if (horizontal > 0)
        {
            isFlip = false;
            foreach (var renderer in spriteRenderers)
            {
                renderer.flipX = isFlip;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTalk = true;
        collision.GetComponent<SpriteRenderer>().enabled = true;
        talker = collision.GetComponent<Transform>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
        collision.GetComponent<SpriteRenderer>().enabled = false;
        talker = null;
    }
}
