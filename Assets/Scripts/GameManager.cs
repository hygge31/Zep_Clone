using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerState
{
    Stop,
    Play
}
public enum WeaponType
{
    MELEE,
    RANGED
}

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public event Action OnChangeName;
    public event Action OnChangeChr;
    public event Action<GameObject> OnChangeCamera;
    public event Action<GameObject> OnTalkInteraction;
    //Attack
    


    public bool onTalkBtn;

    public string name;
    public int charNum;
    public PlayerState playerState = PlayerState.Play;
    public GameObject playerObj;

    public List<GameObject> guest = new List<GameObject>();


    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        SetInit();
    }

    public void SetInit()
    {
        
        name = PlayerPrefs.GetString("name");
        charNum = PlayerPrefs.GetInt("charNum");

      GameObject player =  Instantiate(playerObj, new Vector3(0.5f, 15, 0), Quaternion.identity);
        player.name = "PlayerObj";
    }

    public void CallChangeName()
    {
        if(OnChangeName != null)
        {
            OnChangeName();
        }
    }
    public void CallChangeChr()
    {
        if (OnChangeChr != null)
        {
            OnChangeChr();
        }
    }
    public void CallChangeCamera(GameObject player)
    {
        OnChangeCamera?.Invoke(player);
    }
    public void CallTalkInteraction(GameObject npc) //x 키를 누를때마다 호출
    {
        OnTalkInteraction?.Invoke(npc);
    }

}
