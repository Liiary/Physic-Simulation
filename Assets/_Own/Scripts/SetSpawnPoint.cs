using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform NewSpawnPoint;
    public GameObject BlueLight;
    public GameObject RedLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnPoint.position = NewSpawnPoint.position;
            SpawnPoint.rotation = NewSpawnPoint.rotation;

            BlueLight.SetActive(true);
            RedLight.SetActive(false);
        }
    }
}
