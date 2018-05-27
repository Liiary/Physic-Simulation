using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : SelectCar
{
    private void Start()
    {
        CarNumber = PlayerPrefs.GetInt("CarNumber");
        Cars[CarNumber].gameObject.SetActive(true);
    }
}
