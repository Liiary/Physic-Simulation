using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Musicbox");
        if (musicObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
