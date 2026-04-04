using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        //StartCoroutine(CodeDelay());
    }

    [ServerRpc]
    public void SendInputServerRpc(int input)
    {
        FindFirstObjectByType<GameManagerNetwork>().ReceiveInput(this, input);
    }

    private IEnumerator CodeDelay()
    {
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadSceneAsync(1);
    }
}
