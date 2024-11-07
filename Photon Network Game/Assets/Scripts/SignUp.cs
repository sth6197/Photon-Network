using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Photon.Pun;

public class SignUp : PopUp
{
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;
    [SerializeField] InputField nickNameInputField;

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.ToString());
    }

    public void Failure(PlayFabError playFabError)
    {
        PopUpManager.Instance.Show(PopUpType.TEXT, playFabError.GenerateErrorReport());
    }

    public override void OnConfirm()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
            Username = nickNameInputField.text
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );

        // 1. PhotonNetwork.NickName에 nickNameinputField로 입력한 값을 넣어줍니다.
        PhotonNetwork.NickName = nickNameInputField.text;

        // 2. NickName을 저장합니다.
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        emailInputField.text = "";
        passwordInputField.text = "";
        nickNameInputField.text = "";

        gameObject.SetActive(false);
    }
}
