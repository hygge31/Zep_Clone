using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    // Update is called once per frame


    private void Start()
    {
        GameManager.I.OnChangeCamera += SetGameObj;
    }


    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    public void SetGameObj(GameObject obj)
    {
        player = obj;
    }

    
}
