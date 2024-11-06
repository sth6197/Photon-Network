using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : PopUp
{
    [SerializeField] Text content;

    public override void OnConfirm()
    {
        gameObject.SetActive(false);        
    }
}