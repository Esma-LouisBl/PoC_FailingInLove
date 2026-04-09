using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class SpawnerBehavior : MonoBehaviour
{
    public bool minigameStarted = false;
    public GameObject projectilePrefab;
    [SerializeField]
    private Button startMiniGameButton;
    [SerializeField]
    private GameObject minigameEndedText;
    
    public int numberOfPlayers;
    
    public void StartSpawning()
    {
        if (!minigameStarted)
        {
            minigameStarted = true;
            StartCoroutine(SpawnProjetciles());
        }
    }

    public void EndMinigame()
    {
        print("Minigame ended");
        minigameStarted = false;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            //player.GetComponent<Renderer>().material.color = Color.green;
            player.GetComponent<Renderer>().enabled = true;
            foreach (Renderer r in player.GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
        }
    }

    private IEnumerator SpawnProjetciles()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 10; i++)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            projectile.GetComponent<ProjectileBehavior>().projectileSpeed = 7 + i*0.5f;
            yield return new WaitForSeconds(3f-i*0.2f);
        }
        minigameEndedText.SetActive(true);
        yield return new WaitForSeconds(2f);
        minigameEndedText.SetActive(false);
        EndMinigame();
    }
}
