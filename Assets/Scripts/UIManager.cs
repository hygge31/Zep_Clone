using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    //bottom
    public TMP_InputField inputField;
    public GameObject changeNameUi;
    public GameObject errorMessage;
    public GameObject changeChrUi;

    //right
    public GameObject guestsUi;
    public TextMeshProUGUI guestsText;
    int onGuestUi = -1;
    bool isGuestUi;

    //talkBox
    public bool onTalkBtn;
    public GameObject talkBtn;
    public GameObject talkBox;
    public TextMeshProUGUI talkBoxText;
    GameObject npc;




    private void Start()
    {
        StartCoroutine(ShowTimeCo());
        GameManager.I.OnChangeName += GuestsText;
        GameManager.I.OnTalkInteraction += OnTalkBtn;
    }


    private void Update()
    {
        if(talkBtn.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            //talkBox active, 
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
            talkBtn.SetActive(false);
        }
        else
        {
            npc = _npc;
            talkBtn.SetActive(true);
        }
    }

    void NpcTalk(GameObject npc)
    {
        string[] scripts = npc.GetComponent<NPC>().scripts;

    }
    //---------------------------TalkBox


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


