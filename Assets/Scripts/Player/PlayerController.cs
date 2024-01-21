using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : TopDownCharactorController
{
    Rigidbody2D rigidbody;
    public GameObject mainSprite;
    Animator animator;


    public WeaponController weaponController;



    public float playerSpeed;

    public Collider2D colider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = mainSprite.GetComponent<Animator>();
    }



    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && weaponController.weapon != null)
        {
            OnClickMouse();
        }
    }



    void LateUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);

        if (!CheckNPC(colliders) && GameManager.I.onTalkBtn)
        {
            GameManager.I.CallTalkInteraction(gameObject);
        }
           
    }


    public bool CheckNPC(Collider2D[] colliders)
    {
        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("NPC"))
            {
                return true;
            }
        }
        return false;
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

    public void OnClickMouse()
    {
        if(GameManager.I.playerState == PlayerState.Play)
        {
            Vector2 pot = weaponController.gameObject.transform.position;
            Vector2 worldPot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pot = (worldPot - (Vector2)transform.position).normalized;

            if(weaponController.weapon.weaponType == WeaponType.MELEE)
            {
                Debug.Log("MELEE");
            }
            else
            {
             weaponController.weapon.Instantiate_Projectile(pot);
            }
        }
    }



}
