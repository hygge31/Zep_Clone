using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartSceneController : MonoBehaviour
{
    public Image image;
    public int chrNum;
    public GameObject SelectChr;
    public Sprite[] sprites;
    bool isSelectChrUi;

    public TMP_InputField inputField;
    public GameObject errortext;



    public void OnSelectChrUi()
    {
        if (isSelectChrUi)
        {
            SelectChr.SetActive(false);
        }
        else
        {
            SelectChr.SetActive(true);
        }

        isSelectChrUi = !isSelectChrUi;
    }

    public void Select_1()
    {
        chrNum = 0;
        image.sprite = sprites[chrNum];
        
        OnSelectChrUi();
    }
    public void Select_2()
    {
        chrNum = 1;
        image.sprite = sprites[chrNum];
        OnSelectChrUi();
    }


    public void CheckName()
    {
        string name = inputField.text;

        if (name.Length >= 2 && name.Length <= 10)
        {
            PlayerPrefs.SetString("name", name);
            PlayerPrefs.SetInt("charNum", chrNum);
            SceneManager.LoadScene("Main");
        }
        else
        {
            errortext.SetActive(true);
        }
    }

}
