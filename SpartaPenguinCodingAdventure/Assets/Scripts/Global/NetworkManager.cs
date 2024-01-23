using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Threading;
using Photon.Pun.Demo.Cockpit;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField m_InputField;
    public TMP_Text m_textConnectLog;
    public TMP_Text m_textPlayerList;

    void Start()
    {
        Screen.SetResolution(1980, 1080, false);
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;

        PhotonNetwork.LocalPlayer.NickName = m_InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);

    }
    public override void OnJoinedRoom()
    {
        updatePlayer();

        m_textConnectLog.text += m_InputField.text;
        m_textConnectLog.text += " 님이 방에 참가하였습니다.\n";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayer();

        m_textConnectLog.text += newPlayer.NickName;
        m_textConnectLog.text += " 님이 입장하였습니다.\n";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        updatePlayer();

        m_textConnectLog.text += otherPlayer.NickName;
        m_textConnectLog.text += " 님이 퇴장하였습니다.\n";
    }

    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = m_InputField.text;
        updateNameList();
        PhotonNetwork.ConnectUsingSettings();
    }

    void updatePlayer()
    {
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            m_textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
            m_textPlayerList.text += "\n";
        }
    }
    void updateNameList()
    {
        m_textPlayerList.text = "";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            m_textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
            m_textPlayerList.text += "\n";
        }
    }
}


