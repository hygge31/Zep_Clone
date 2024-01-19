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

    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Color color = Color.blue;
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 2);
    }




    public void OnMove(InputValue value)
    {

        if(GameManager.I.playerState == PlayerState.Play)
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

    }
    public void OnMouse(InputValue value)
    {
        if (GameManager.I.playerState == PlayerState.Play)
        {
        Vector2 newAim = value.Get<Vector2>();
            Vector2 worldPot = Camera.main.ScreenToWorldPoint(newAim);
            newAim = (worldPot - (Vector2)transform.position).normalized;
            CallLookEvent(newAim);
        }
           
        
    }



}
