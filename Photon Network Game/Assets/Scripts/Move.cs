using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 direction;

    public void OnKeyUpdate()
    {
        // direction.x�� ���� ���� �޽��ϴ�.
        direction.x = Input.GetAxisRaw("Horizontal");

        // direction.z�� ���� ���� �޽��ϴ�.
        direction.z = Input.GetAxisRaw("Vertical");

        // direction ������ ���� ���ͷ� �����մϴ�.
        direction.Normalize();
    }

    public void OnMove(Rigidbody rigidbody)
    {
        rigidbody.position += rigidbody.transform.TransformDirection(direction * speed * Time.deltaTime);
    }
}
