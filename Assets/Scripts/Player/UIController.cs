using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private void Start()
    {
        text.text = GameManager.I.name;
        GameManager.I.OnChangeName += ChangeName;
    }

    void ChangeName()
    {
        text.text = GameManager.I.name;
    }


}
