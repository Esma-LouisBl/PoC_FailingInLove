using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public GameObject playerUI, serverUI, connectionUI, crushUI;
    public TextMeshProUGUI myNumberAsPlayerText;

    public NetworkVariable<int> numberOfPlayers;
    public int myNumberAsPlayer;
    public SpawnerBehavior spawner;
    
    public PlayerNetwork myPlayer;
    
    public void SetPlayer()
    {
        if(!IsOwner)
        {
            connectionUI.SetActive(false);
            playerUI.SetActive(true);
            //numberOfPlayers.Value++;
            //myNumberAsPlayer = numberOfPlayers.Value;
            //myNumberAsPlayerText.text = myNumberAsPlayer.ToString();
        }
    }
    
    public void SetServer()
    {
        if(IsOwner)
        {
            connectionUI.SetActive(false);
            serverUI.SetActive(true);
        }
    }

    public void ShowCrush()
    {
        crushUI.SetActive(true);
    }
    
    public void StartMiniGame()
    {
        spawner.StartSpawning();
    }

    public void PlayerNameButton(TextMeshProUGUI playerName)
    {
        string absoluteName = playerName.text;
        myPlayer.SendPlayerNameServerRpc(absoluteName);
    }
}
