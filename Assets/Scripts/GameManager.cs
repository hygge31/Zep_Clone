using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public string name;
    public int charNum;
    public GameObject[] players;

    private void Awake()
    {
        I = this;
        SetInit();
    }

    public void SetInit()
    {
        
        name = PlayerPrefs.GetString("name");
        charNum = PlayerPrefs.GetInt("charNum");

      GameObject player =  Instantiate(players[charNum], new Vector3(0.5f, 15, 0), Quaternion.identity);
        player.name = "Player";
    }




    
}
