using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    TopDownCharactorController controller;
    Rigidbody2D rigidbody;
    Vector2 moveDir = Vector2.zero;
    Vector2 lookDir = Vector2.zero;
    public GameObject mainSprite;

    private void Awake()
    {
        controller = GetComponent<TopDownCharactorController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnLookEvent += LookAt;
    }
    private void FixedUpdate()
    {
        ApplyMovement(moveDir);
    }

    void Move(Vector2 dir)
    {
        moveDir = dir;
    }

    void ApplyMovement(Vector2 dir)
    {
        dir *= 5 * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + dir);
    }

    void LookAt(Vector2 dir)
    {
        lookDir = dir;

        if(dir.x > 0)
        {
            mainSprite.transform.localScale = new Vector3(1, 1, 1);
        }else if(dir.x < 0)
        {
            mainSprite.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
