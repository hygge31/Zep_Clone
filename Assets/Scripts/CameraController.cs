using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPotition;
    public Vector3 offset;
    // Update is called once per frame

    private void Start()
    {
        playerPotition = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.position = playerPotition.position + offset;
    }
}
