using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public abstract class PopUp : MonoBehaviourPunCallbacks
{
    public abstract void OnConfirm();
}