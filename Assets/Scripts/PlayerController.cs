using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : TopDownCharactorController
{
    Rigidbody2D rigidbody;
    public GameObject mainSprite;
    Animator animator;
    public float playerSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = mainSprite.GetComponent<Animator>();
    }

   

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        if (moveInput.magnitude != 0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        CallMoveEvent(moveInput);
    }
    public void OnMouse(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPot = Camera.main.ScreenToWorldPoint(newAim);
        newAim = (worldPot - (Vector2)transform.position).normalized;
        CallLookEvent(newAim);
        
    }



}
