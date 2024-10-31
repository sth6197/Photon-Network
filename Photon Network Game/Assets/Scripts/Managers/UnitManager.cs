using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class UnitManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }

    public IEnumerator Create()
    {
        while (true) // 5초마다 몬스터 오브젝트 생성
        {
            PhotonNetwork.InstantiateRoomObject("Rake", Vector3.zero, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient) // 마스터 클라 권한 이양시 한번 더 호출
        {
            StartCoroutine(Create());
        }
    }
}