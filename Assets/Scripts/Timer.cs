using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : SelectCar
{
    public Image FinishImage;
    public Text TimeText;
    public Text FinishText;
    public static bool finish;
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
            Cars[CarNumber].GetComponent<CarController>().enabled = false;
            FinishImage.gameObject.SetActive(true);
            FinishText.text = "FINISH!\nTime: " + TimeText.text + "\nPress Q to go to the Main Menu\n Press R to restart\nPress C to change your Car";

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                Cars[CarNumber].GetComponent<CarController>().enabled = true;
                Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
                FinishImage.gameObject.SetActive(false);
                finish = false;
                SceneManager.LoadScene(2);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1;
                Cars[CarNumber].GetComponent<CarController>().enabled = true;
                Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
                FinishImage.gameObject.SetActive(false);
                finish = false;
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Time.timeScale = 1;
                Cars[CarNumber].GetComponent<CarController>().enabled = true;
                Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
                FinishImage.gameObject.SetActive(false);
                finish = false;
                SceneManager.LoadScene(1);
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
