using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using WebSocketSharp;

public class NickNameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject nickNamePanel;

    void Start()
    {
        // 1. PhotonNetwork.NickName�� ����� String ���� �ҷ��ɴϴ�.
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        // 2. PhotonNetwork.NickName�� ��� �ִٸ� nickNamePanel�� Ȱ��ȭ�մϴ�.
        if (PhotonNetwork.NickName.IsNullOrEmpty())
        {
            nickNamePanel.SetActive(true);
        }
    }

    public void OnSetNickName()
    {
        // 1. PhotonNetwork.NickName�� inputField�� �Է��� ���� �־��ݴϴ�.
        PhotonNetwork.NickName = inputField.text;

        // 2. NickName�� �����մϴ�.
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        // 3. nickNamePanel ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        nickNamePanel.SetActive(false);
    }
}