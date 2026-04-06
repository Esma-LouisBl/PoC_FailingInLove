using UnityEngine;
using Unity.Netcode;

public class ServerManager : MonoBehaviour
{
    public GameManager gameManager;
    
    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        gameManager.SetServer();
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        gameManager.SetPlayer();
    }
}
