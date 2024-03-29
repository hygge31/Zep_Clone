using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string name = "";
    public string[] scripts;


    private void Awake()
    {
        name = gameObject.name;
    }
    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);
        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player") && !GameManager.I.onTalkBtn )
                {
                    GameManager.I.CallTalkInteraction(gameObject);
                }
            }
        }


    }

}
