using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManagerNetwork : NetworkBehaviour
{
    private List<PlayerNetwork> players = new List<PlayerNetwork>();

    public void RegisterPlayer(PlayerNetwork player)
    {
        players.Add(player);
        Debug.Log("Joueur ajouté. Total : " + players.Count);
        
     //Note : Si un joueur s'en va, ça ne l'enlève pas de la liste
    }

    public void ReceiveInput(PlayerNetwork player, int input)
    {
        Debug.Log($"Input reçu de {player} : {input}");
        
        if (input == 1)
        {
            player.GetComponent<Transform>().position += Vector3.right;
        }
    }
}
