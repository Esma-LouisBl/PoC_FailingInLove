using System;
using TMPro;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public GameObject playerUI, serverUI, connectionUI, crushUI;
    public TextMeshProUGUI numberOfPlayersText, myNumberAsPlayerText;

    public NetworkVariable<int> numberOfPlayers;
    public int myNumberAsPlayer;
    
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

    private void Update()
    {
        if (IsOwner)
        {
            numberOfPlayersText.text = numberOfPlayers.Value.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print(numberOfPlayers.Value);
        }
    }

    public void ShowCrush()
    {
        crushUI.SetActive(true);
    }
}
