using System;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int direction = 1;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        gameObject.transform.localPosition += new Vector3(7f * Time.deltaTime * direction, 0, 0);
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
}
