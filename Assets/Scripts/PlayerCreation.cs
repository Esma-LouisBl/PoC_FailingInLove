using UnityEngine;

public class PlayerCreation : MonoBehaviour
{
    private PlayerNetwork playerNetwork;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNetwork = FindFirstObjectByType<PlayerNetwork>();
    }

    // public void ConfirmName(string name)
    // {
    //     playerNetwork.SendInputServerRpc(13);
    // }
    
    //ESSAYE DE VOIR POUR PASSER LE NOM DANS LE PLAYERNETWORK EN VARIABLE DE CELUI CI
    //ENSUITE TU LE CHOPES DANS LE GAMEMANAGERNETWORK, GENRE AVEC UN SENDINPUT QUI PERMET DE RECUP AVEC UN PLAYER.NAME
}
