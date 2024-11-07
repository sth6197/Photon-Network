using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNameText;
    [SerializeField] Camera remoteCamera;

    private void Awake()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
    }

    void Start()
    {
        remoteCamera = Camera.main;
        nickNameText.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        transform.forward = remoteCamera.transform.forward;
    }   
}