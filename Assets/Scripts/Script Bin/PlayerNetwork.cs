using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : NetworkBehaviour
{
    public int playerId;
    public GameManagerNetwork gameManagerNetwork;

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
