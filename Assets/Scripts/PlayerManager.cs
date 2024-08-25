using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public float speed = 0.05f;

    Animator animator;
    SpriteRenderer[] spriteRenderers;
    bool canMove;
    bool isFlip;
    Transform talker;

    private void OnEnable()
    {
        EventHandler.DialogueEndEvent += OnDialogueEnd;
    }

    private void OnDisable()
    {
        EventHandler.DialogueEndEvent -= OnDialogueEnd;
    }

    private void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
        spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        PlayerWalk();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueManager.Instance.CanPlayDialogue())
            {
                canMove = false;
                animator.SetBool("IsWalk", false);               
                DialogueManager.Instance.PlayDialogue(true);
            }       
        }
    }

    private void PlayerWalk()
    {
        if (!canMove) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("IsWalk", true);
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

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

    private void OnDialogueEnd()
    {   
        talker = null;
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogueTip"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = true;
            talker = collision.GetComponent<Transform>();
            DialogueObject diglogue = talker.GetComponent<DialogueTip>().GetDialogue();
            DialogueManager.Instance.SetDialogue(diglogue);
        }     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogueTip"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }           
    }
}
