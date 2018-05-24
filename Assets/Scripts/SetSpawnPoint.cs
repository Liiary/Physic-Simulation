using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform NewSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnPoint.position = NewSpawnPoint.position;
            SpawnPoint.rotation = NewSpawnPoint.rotation;
        }
    }
}
