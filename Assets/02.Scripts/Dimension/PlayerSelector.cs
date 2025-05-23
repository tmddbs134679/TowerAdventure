using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSelector : GenericSingleton<PlayerSelector>
{
    [Header("Player Settings")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private List<PlayerStateMachine> allPlayers;
    [HideInInspector] public PlayerStateMachine selectedPlayer;

    [Header("Camera Settings")]
    [SerializeField] CinemachineFreeLook freeLookCam;


    protected override void Awake()
    {
        base.Awake();

        SelectPlayer(0);
    }

    public void SelectPlayer(int idx)
    {

        if (selectedPlayer != null)
        {
            selectedPlayer.DisconnectInput(); // 입력 연결 해제
            selectedPlayer.gameObject.SetActive(false);
        }

        //캠 Setting
       
         
        selectedPlayer = allPlayers[idx];
        selectedPlayer.ConnectInput(inputReader); // 입력 연결

        FollowCam();
        allPlayers[idx].gameObject.SetActive(true);
    }

    public void FollowCam()
    {
        freeLookCam.Follow = selectedPlayer.FollowCam.transform;
    }
}
