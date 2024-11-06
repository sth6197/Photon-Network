using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pause : PopUp
{
    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    public override void OnConfirm()
    {
        MouseManager.Instance.SetMouse(false);

        gameObject.SetActive(false);
    }
}