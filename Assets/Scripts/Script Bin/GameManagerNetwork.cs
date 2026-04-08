using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerNetwork : NetworkBehaviour
{
    private List<PlayerNetwork> players = new List<PlayerNetwork>();
    public NetworkVariable<int> numberOfPlayers;
    public GameObject startMiniGameButton;
    
    private bool canJump = true;
    private Vector3 jumpVector = new Vector3(0, 0.3f, 0);
    
    public void RegisterPlayer(PlayerNetwork player)
    {
        if (IsServer)
        {
            players.Add(player);
            numberOfPlayers.Value = players.Count;
            //Debug.Log("Joueur ajouté. Total : " + players.Count);
        }
        //Note : Si un joueur s'en va, ça ne l'enlève pas de la liste
    }

    public void JumpWithButton()
    {
        var player = FindFirstObjectByType(typeof(PlayerNetwork)) as PlayerNetwork;
        player.GetComponent<InputSender>().Jump();
    }

    public void ReceiveInput(PlayerNetwork player, int input)
    {
        //Debug.Log($"Input reçu de {player} : {input}");
        switch (input)
        {
            case 1: //Move
                player.GetComponent<Transform>().position += Vector3.right;
                break;
            case 2: //Jump
                StartCoroutine(Jump(player));
                break;
            case 3: //Init Player
                gameObject.GetComponent<GameManager>().myNumberAsPlayer = numberOfPlayers.Value;
                gameObject.GetComponent<GameManager>().myNumberAsPlayerText.text = "Player : " + gameObject.GetComponent<GameManager>().myNumberAsPlayer.ToString();
                player.transform.position = new Vector3(gameObject.GetComponent<GameManager>().myNumberAsPlayer+0.2f, 0.5f, 0);
                if (players.Count > 0 && IsServer)
                {
                    startMiniGameButton.SetActive(true);
                }
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

    private IEnumerator Jump(PlayerNetwork player)
    {
        if (canJump)
        {
            canJump = false;
            player.GetComponent<Transform>().position += jumpVector;
            yield return new WaitForSeconds(1f);
            player.GetComponent<Transform>().position -= jumpVector;
            yield return new WaitForSeconds(1f);
            canJump = true;
        }
    }
}
