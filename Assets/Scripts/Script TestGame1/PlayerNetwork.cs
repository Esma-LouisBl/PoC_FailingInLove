using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : NetworkBehaviour
{
    public int playerId, playerNumber;
    public GameManagerNetwork gameManagerNetwork;

    private GameManager _gameManager;
    
    [NotNull] public GameObject canvasToEnable, canvasHair, canvasFace, canvasBody, canvasAccessories, canvasStartCrush;

    public override void OnNetworkSpawn()
    {
        gameManagerNetwork = FindFirstObjectByType<GameManagerNetwork>();
        _gameManager = FindFirstObjectByType<GameManager>();
        
        if (IsServer)
        {
            playerId = OwnerClientId.GetHashCode();
            FindFirstObjectByType<GameManagerNetwork>().RegisterPlayer(this);
        }
        StartCoroutine(InitWithDelay());
        if (IsOwner)
        {
            StartCoroutine(GetIdWithDelay());
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
        //doesnt work, should maybe disable itself instead of all others ? dunno, things to try, it works anyway when canvas are disabled
        //otherwise, there is still the 2-2 problem on screens, even if players don't notice it -> maybe it's linked to the canvas issue as well ?
        if (IsOwner)
        {
            canvasToEnable.SetActive(true);
        }
    }

    public void LoadCrushCreation()
    {
        if (IsOwner)
        {
            canvasStartCrush.SetActive(false);
            switch (playerNumber)
            {
                case 1:
                    canvasHair.SetActive(true);
                    break;
                case 2:
                    canvasFace.SetActive(true);
                    break;
                case 3:
                    canvasBody.SetActive(true);
                    break;
                case 4:
                    canvasAccessories.SetActive(true);
                    break;
            }
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
    
    private IEnumerator GetIdWithDelay()
    {
        yield return new WaitForSeconds(0.02f);
        playerNumber = _gameManager.myNumberAsPlayer;
        
        canvasStartCrush.SetActive(true); //Je pose ça là pour le moment histoire de l'activer dès le début mais pas chez tout le monde
        
    }
}
