using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCar : MonoBehaviour
{
    public GameObject[] Cars;
    public int CarNumber;

    public void SelectingNextCar()
    {
        Cars[CarNumber].gameObject.SetActive(false);
        CarNumber++;

        if (CarNumber == 3)
        {
            CarNumber = 0;
        }

        Cars[CarNumber].gameObject.SetActive(true);
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
    }
}
