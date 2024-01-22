using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    //bottom
    [Header("Bottom UI")]
    public TMP_InputField inputField;
    public GameObject changeNameUi;
    public GameObject errorMessage;
    public GameObject changeChrUi;

    //right
    [Header("Right UI")]
    public GameObject guestsUi;
    public TextMeshProUGUI guestsText;
    int onGuestUi = -1;
    bool isGuestUi;

    //talkBox
    [Header("Talk UI")]
    public bool onTalkBtn;
    public bool isTalking;
    public int npcSpriteIdx = -1;
    public GameObject talkBtn;
    public GameObject talkBox;
    public TextMeshProUGUI talkBox_Name;
    public TextMeshProUGUI talkBoxText;
    public GameObject talkNextBtn;
    public GameObject talkEndBtn;
    public GameObject npc;

    //Minimap
    [Header("Minimap UI")]
    public GameObject minimap;



    private void Start()
    {
        StartCoroutine(ShowTimeCo());
        GameManager.I.OnChangeName += GuestsText;
        GameManager.I.OnTalkInteraction += OnTalkBtn;
    }


    private void Update()
    {
        if(talkBtn.activeSelf && !isTalking && Input.GetKeyDown(KeyCode.X))
        {
            talkBtn.SetActive(false);
            isTalking = true;
            talkBox.SetActive(true);
            NpcSparitsNext();
        }

    }



    //---------------------------Time
    IEnumerator ShowTimeCo()
    {
        string time;
        while (true)
        {
            time = DateTime.Now.ToString("HH:mm");
            timeText.text = time;
            yield return new WaitForSeconds(1);
        }
    }
    //---------------------------Time

    //---------------------------RightUi
    public void GuestsText()
    {
       guestsText.text = GameManager.I.name +" ( 나 )\n";
       foreach(GameObject name in GameManager.I.guest)
        {
            guestsText.text += name.name + "\n";
        }
    }

    public void ShowRightUi()
    {
        if (!isGuestUi)
        {
            GuestsText();
            isGuestUi = true;
            guestsUi.SetActive(true);
        }
        else
        {
            isGuestUi = false;
            guestsUi.SetActive(false);
        }
     
    }



    public void Choice_1()
    {
        GameManager.I.charNum = 0;
        GameManager.I.CallChangeChr();
        changeChrUi.SetActive(false);
    }

    public void Choice_2()
    {
        GameManager.I.charNum = 1;
        GameManager.I.CallChangeChr();
        changeChrUi.SetActive(false);
    }


    //---------------------------RightUi

    //---------------------------BottomUi
    public void ShowChangeNameUi()
    {
        if (changeNameUi.activeSelf)
        {
            GameManager.I.playerState = PlayerState.Play;
            errorMessage.SetActive(false);
            changeNameUi.SetActive(false);
        }
        else
        {
            GameManager.I.playerState = PlayerState.Stop;
            changeNameUi.SetActive(true);
        }
        
    }
    public void SetName()
    {
        if(inputField.text.Length >=2 && inputField.text.Length <= 10)
        {
            GameManager.I.name = inputField.text;
            GameManager.I.CallChangeName();
            GameManager.I.playerState = PlayerState.Play;
            errorMessage.SetActive(false);
            changeNameUi.SetActive(false);
        }
        else
        {
            errorMessage.SetActive(true);
        }
       
    }


    public void ShowChangeChrUi()
    {
        if (changeChrUi.activeSelf)
        {
            changeChrUi.SetActive(false);
        }
        else
        {
            changeChrUi.SetActive(true);
        }
    }

    //---------------------------BottomUi
    //---------------------------TalkBox
    public void OnTalkBtn(GameObject _npc)
    {
        if (talkBtn.activeSelf)
        {
            npc = null;
            CloseTalkBox();
            GameManager.I.onTalkBtn = false;
            talkBtn.SetActive(false);
        }
        else
        {
            npc = _npc;
            GameManager.I.onTalkBtn = true;
            talkBtn.SetActive(true);
        }
    }

    public void NpcSparitsNext()
    {
        npcSpriteIdx++;
        NPC npc = this.npc.GetComponent<NPC>();
        talkBox_Name.text = npc.name;
        talkBoxText.text = npc.scripts[npcSpriteIdx];
        if (npcSpriteIdx + 1 == npc.scripts.Length)
        {
            talkNextBtn.SetActive(false);
            talkEndBtn.SetActive(true);
        }
        else
        {
            talkNextBtn.SetActive(true);
        }

    }

    public void CloseTalkBox()
    {
        talkEndBtn.SetActive(false);
        talkBox.SetActive(false);
        isTalking = false;
        npcSpriteIdx = -1;
    }

    //---------------------------TalkBox
    //---------------------------Minimap
    public void ShowMinimap()
    {
        if (minimap.activeSelf)
        {
            minimap.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
        }
    }
    //---------------------------Minimap


    IEnumerator MoveUiCo(GameObject Ui,Vector3 vec)
    {
        float percent = 0;
        Vector3 pot = Ui.transform.position;
        while (percent <1)
        {
            percent += Time.deltaTime*5;
            Ui.transform.position = Vector3.Lerp(pot, vec, percent);
            yield return new WaitForSeconds(.01f);
        }
        isGuestUi = false;
    }
}


