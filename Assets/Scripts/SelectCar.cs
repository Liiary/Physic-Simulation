using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCar : MonoBehaviour
{
    public GameObject[] Cars;
    public int CarNumber;

    public void Start()
    {
        CarNumber = 0;
    }

    public void SelectingNextCar()
    {
        Cars[CarNumber].gameObject.SetActive(false);
        CarNumber++;

        if (CarNumber == 3)
        {
            CarNumber = 0;
        }

        Cars[CarNumber].gameObject.SetActive(true);
        PlayerPrefs.SetInt("CarNumber", CarNumber);
    }

    public void SelectingPreviousCar()
    {
        Cars[CarNumber].gameObject.SetActive(false);
        CarNumber--;

        if(CarNumber == -1)
        {
            CarNumber = 2;
        }

        Cars[CarNumber].gameObject.SetActive(true);
        PlayerPrefs.SetInt("CarNumber", CarNumber);
    }
}
