using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;

public class GameManagerNetwork : NetworkBehaviour
{
    private List<PlayerNetwork> players = new List<PlayerNetwork>();
    public NetworkVariable<int> numberOfPlayers;

    public void RegisterPlayer(PlayerNetwork player)
    {
        if (IsServer)
        {
            players.Add(player);
            numberOfPlayers.Value = players.Count;
            Debug.Log("Joueur ajouté. Total : " + players.Count);
        }
        //Note : Si un joueur s'en va, ça ne l'enlève pas de la liste
    }

    public void ReceiveInput(PlayerNetwork player, int input)
    {
        Debug.Log($"Input reçu de {player} : {input}");
        switch (input)
        {
            case 1: //Move
                player.GetComponent<Transform>().position += Vector3.right;
                break;
            case 2: //Increment
                FindFirstObjectByType<DebugScript>().Increment();
                break;
            case 3: //Init Player
                print("initiating player");
                print(numberOfPlayers.Value.ToString());
                gameObject.GetComponent<GameManager>().myNumberAsPlayer = numberOfPlayers.Value;
                gameObject.GetComponent<GameManager>().myNumberAsPlayerText.text = gameObject.GetComponent<GameManager>().myNumberAsPlayer.ToString();
                player.transform.position = new Vector3(gameObject.GetComponent<GameManager>().myNumberAsPlayer+0.2f, 0.5f, 0);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print(numberOfPlayers.Value.ToString());
        }
    }
}
