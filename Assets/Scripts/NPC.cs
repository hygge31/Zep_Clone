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
        if(colliders.Length > 0)
        {

        }
    }

    private void OnDrawGizmos()
    {
        Color color = Color.blue;
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 2);
    }

    //OverlapSphere , player가 있으면 CallTalkInteraction,
}
