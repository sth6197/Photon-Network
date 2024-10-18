using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform parentTransform;

    [SerializeField] InputField roomNameInputField;
    [SerializeField] InputField roomCapacityInputField;

    Dictionary <string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        InstantiateRoom();
    }

    public GameObject InstantiateRoom()
    {
        // 1. Room 오브젝트를 생성합니다.
        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

        // 2. Room 오브젝트의 부모 위치를 설정합니다.
        room.transform.SetParent(parentTransform);

        // 3. Room 오브젝트를 반환합니다.
        return room;
    }
}
