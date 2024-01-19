using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectChar : MonoBehaviour
{
    public GameObject[] chr;
    int chrIdx = 0;


    private void Start()
    {
        GameManager.I.OnChangeChr += ChangeChr;
        Init();
    }


    private void Init() 
    {
        chr[0].SetActive(true);
        GameManager.I.CallChangeCamera(chr[0]);
    }


    void ChangeChr()
    {
        chrIdx = GameManager.I.charNum;
        foreach(GameObject obj in chr)
        {
            obj.transform.position = transform.position;
            obj.SetActive(false);
        }
        GameManager.I.CallChangeCamera(chr[chrIdx]);
        chr[chrIdx].SetActive(true);
    }
    

}
