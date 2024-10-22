using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void RotateX()
    {
        // mouseY에 마우스로 입력한 값을 저장합니다. "Mouse Y"
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // MouseY의 값을 -65 ~ 65 사이의 값으로 제한합니다.
        // mouseY <- Mathf.Clamp(제한하려는 값, 최소값, 최대값)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        // transform.EulerAngles
        transform.eulerAngles = new Vector3(-mouseY, 0, 0);
    }
}