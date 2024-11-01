using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rifle : MonoBehaviourPunCallbacks
{
    private Ray ray;
    private RaycastHit raycastHit;

    [SerializeField] Camera camera;
    [SerializeField] LayerMask layerMask;

    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
            ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonView = raycastHit.collider.GetComponent<PhotonView>();

                if(photonView.IsMine)
                {
                    photonView.GetComponent<Rake>().Die();

                }
            }
       }
    }
}
