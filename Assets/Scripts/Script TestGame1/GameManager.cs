using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public GameObject playerUI, serverUI, connectionUI;
    
    public void SetPlayer()
    {
        if(!IsOwner)
        {
            connectionUI.SetActive(false);
            playerUI.SetActive(true);
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
}
