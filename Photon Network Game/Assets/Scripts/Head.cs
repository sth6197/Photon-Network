using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviour
{
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    void Update()
    {
        rotation.RotateX();
    }

}
