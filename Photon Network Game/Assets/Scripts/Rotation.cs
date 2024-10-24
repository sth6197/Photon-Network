using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void OnKeyUpdate()
    {
        // mouseX�� ���콺�� �Է��� ���� �����մϴ�.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3 (0, mouseX, 0);
    }

    public void RotateX()
    {
        // mouseY�� ���콺�� �Է��� ���� �����մϴ�. "Mouse Y"
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // MouseY�� ���� -65 ~ 65 ������ ������ �����մϴ�.
        // mouseY <- Mathf.Clamp(�����Ϸ��� ��, �ּҰ�, �ִ밪)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        // transform.localEulerAngles
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}