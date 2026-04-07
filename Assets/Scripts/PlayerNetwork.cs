using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public int playerId;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            playerId = OwnerClientId.GetHashCode();
            FindFirstObjectByType<GameManagerNetwork>().RegisterPlayer(this);
        }
    }

    [ServerRpc]
    public void SendInputServerRpc(int input)
    {
        FindFirstObjectByType<GameManagerNetwork>().ReceiveInput(this, input);
    }
}