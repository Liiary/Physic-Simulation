using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject Car;
    public Text TimeText;
    public Text FinishText;
    private bool finish;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (!finish)
        {
            float timer = Time.time - startTime;

            string seconds = (timer % 60).ToString("f3");
            string minutes = ((int)timer / 60).ToString();

            TimeText.text = minutes + ":" + seconds;
        }

        if (finish)
        {
            Time.timeScale = 0;
            Car.GetComponent<CarController>().enabled = false;
            FinishText.text = "FINISH!\n" + TimeText.text + "\nPress Q to go to the Main Menu\n Press R to restart";

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                Car.GetComponent<CarController>().enabled = true;
                SceneManager.LoadScene(1);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1;
                Car.GetComponent<CarController>().enabled = true;
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            finish = true;
        }
    }
}
