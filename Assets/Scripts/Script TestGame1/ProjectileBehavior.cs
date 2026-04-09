using System;
using System.Collections;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int direction = 1;
    public float projectileSpeed = 7f;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        StartCoroutine(DestroyProjectileAfterDelay(15f));
    }

    void Update()
    {
        gameObject.transform.localPosition += new Vector3(projectileSpeed * Time.deltaTime * direction, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        //other.GetComponent<Renderer>().material.color = Color.red;
        other.GetComponent<Renderer>().enabled = false;
        foreach (Renderer r in other.GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    private IEnumerator DestroyProjectileAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
