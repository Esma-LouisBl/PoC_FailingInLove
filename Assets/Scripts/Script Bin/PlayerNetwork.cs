using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : NetworkBehaviour
{
    public int playerId;
    public GameManagerNetwork gameManagerNetwork;
    
    public GameObject canvasToEnable;

    public override void OnNetworkSpawn()
    {
        gameManagerNetwork = FindFirstObjectByType<GameManagerNetwork>();
        if (IsServer)
        {
            playerId = OwnerClientId.GetHashCode();
            FindFirstObjectByType<GameManagerNetwork>().RegisterPlayer(this);
        }
        StartCoroutine(InitWithDelay());
        if (IsOwner)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
        //doesnt work, should maybe disable itself instead of all others ? dunno, things to try, it works anyway when canvas are disabled
        //otherwise, there is still the 2-2 problem on screens, even if players don't notice it -> maybe it's linked to the canvas issue as well ?
        if (IsOwner)
        {
            canvasToEnable.SetActive(true);
        }
    }

    [ServerRpc]
    public void SendInputServerRpc(int input)
    {
        FindFirstObjectByType<GameManagerNetwork>().ReceiveInput(this, input);
    }

    private IEnumerator InitWithDelay()
    {
        yield return new WaitForSeconds(0.02f);
        gameManagerNetwork.ReceiveInput(this, 3);
    }
}
