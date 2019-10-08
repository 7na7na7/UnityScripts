using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Random = System.Random;

public class NetworkManager : MonoBehaviourPunCallbacks
{
  public InputField NickNameInput;
  public GameObject DisconnectPanel;
  public GameObject RespawnPanel;

  void Awake()
  {
    Screen.SetResolution(960, 540, false);
    PhotonNetwork.SendRate = 60;
    PhotonNetwork.SerializationRate = 30;
  }

  public void Connect()
  {
    PhotonNetwork.ConnectUsingSettings(); //
  }

public override void OnConnectedToMaster()
  {
    PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
    PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
  }

  public override void OnJoinedRoom()
  {
    DisconnectPanel.SetActive(false);
    StartCoroutine(DestroyBullet());
    Spawn();
  }
  IEnumerator DestroyBullet() //리스폰할 때 모든 총알 제거
  {
    yield return new WaitForSeconds(0.2f);
    foreach (GameObject GO in GameObject.FindGameObjectsWithTag("Bullet")) GO.GetComponent<PhotonView>().RPC("DestroyRPC", RpcTarget.All);
  }
  public void Spawn()
  {
    PhotonNetwork.Instantiate("Player", new Vector3(UnityEngine.Random.Range(7,16),4,0), Quaternion.identity);
    RespawnPanel.SetActive(false);
  }
  void Update() { if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected) PhotonNetwork.Disconnect(); }
  public override void OnDisconnected(DisconnectCause cause)
  {
    DisconnectPanel.SetActive(true);
    RespawnPanel.SetActive(false);
  }
}
