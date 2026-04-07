using TMPro;
using UnityEngine;
using Unity.Netcode;

public class Library : NetworkBehaviour
{
    public TextMeshProUGUI state;
    public PlayerController playerController;
    
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner)
        {
            playerController.enabled = false;
        }
    }
    void Update()
    {
        if (IsOwner)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            GameObject.Find("State").GetComponent<TextMeshProUGUI>().text = "Player";
        }
        if (IsServer)
        {
            GameObject.Find("State").GetComponent<TextMeshProUGUI>().text = "Server";
        }
    }
}
