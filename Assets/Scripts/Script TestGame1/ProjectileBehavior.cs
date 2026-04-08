using System;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int direction = 1;
    void Update()
    {
        gameObject.transform.localPosition += new Vector3(7f * Time.deltaTime * direction, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
    }
}
