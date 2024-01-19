using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject guestsUi;
    int onGuestUi = -1;

    private void Start()
    {
        StartCoroutine(ShowTimeCo());
    }
    
    

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



    public void ShowRightUi()
    {
      Vector3 vec = guestsUi.GetComponent<RectTransform>().position;
        vec.x += 5f * onGuestUi;

        StartCoroutine(MoveUiCo(guestsUi, vec));
        onGuestUi *= -1;
    }


    IEnumerator MoveUiCo(GameObject Ui,Vector3 vec)
    {
        float percent = 0;
        while (percent <1)
        {
            percent += Time.deltaTime;
            Ui.transform.position = Vector3.Lerp(Ui.transform.position, vec, percent);
            yield return new WaitForSeconds(.5f);
        }
    }
}
//752 : 14 , 445 : 9