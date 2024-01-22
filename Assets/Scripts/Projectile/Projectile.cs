using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigibody;
    public Vector2 dir;
    public ParticleSystem particle;





    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (dir != Vector2.zero)
        {
            transform.position += (Vector3)dir*Time.deltaTime*10;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(Instantiate(particle, transform.position, Quaternion.identity),2);
    }

}


