using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerBehavior : MonoBehaviour
{
    public bool minigameStarted = false;
    public GameObject projectilePrefab;
    [SerializeField]
    private Button startMiniGameButton;
    
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
    }

    private IEnumerator SpawnProjetciles()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(projectilePrefab);
        }
        yield return new WaitForSeconds(3f);
        EndMinigame();
    }
}
