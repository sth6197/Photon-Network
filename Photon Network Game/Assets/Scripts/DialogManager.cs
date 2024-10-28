using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) return;

            // inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
            // (string ����) <= Photon �г��� + : + InputField�� ������ ���ڿ�

            string talk = photonView.Owner.NickName + " : " + inputField.text;

            // RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ��� �����϶�� ����� �����մϴ�.

            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    // ä�� ȣ��
    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text ���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        // Prefab ������Ʈ�� Text ������Ʈ�� �����ؼ� text�� ���� �����մϴ�.
        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - content ������Ʈ�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTransform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField()
;
        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
        inputField.text = "";
    }
}
