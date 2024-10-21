using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        
    }

    public void DisableCamera()
    {
        // ���� �÷��̾ �� �ڽ��̶��
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }

}
