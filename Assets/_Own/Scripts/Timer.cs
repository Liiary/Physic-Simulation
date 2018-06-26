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
    public Text StartCountDownText;
    public static bool finish;

    private bool countDown;
    private float startCountDown = 3f;
    private float startTime;

    private void Start()
    {
        CarNumber = PlayerPrefs.GetInt("CarNumber");
        StartCountDownText.text = "3";
        countDown = true;
    }

    private void Update()
    {
        if (!finish)
        {
            if (CarController.PauseGame)
            {
                return;
            }

            if (countDown)
            {
                Cars[CarNumber].GetComponent<CarController>().enabled = false;
                startCountDown -= Time.deltaTime;

                if (startCountDown <= 2)
                {
                    StartCountDownText.text = "2";
                }
              
                if (startCountDown <= 1)
                {
                    StartCountDownText.text = "1";
                }

                if (startCountDown <= 0)
                {
                    StartCountDownText.text = "Go";
                    startTime = Time.time;
                    Cars[CarNumber].GetComponent<CarController>().enabled = true;
                    countDown = false;
                }
                return;
            }

            
            float timer = Time.time - startTime;

            string seconds = (timer % 60).ToString("f3");
            string minutes = ((int)timer / 60).ToString();

            TimeText.text = minutes + ":" + seconds; 
            
            if(timer >= 1 && timer <= 2)
            {
                StartCountDownText.text = "";
            }
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
                CarNumber = 0;
                finish = false;
                PlayerPrefs.SetInt("CarNumber", CarNumber);
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Time.timeScale = 1;
                Cars[CarNumber].GetComponent<CarController>().enabled = true;
                Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
                FinishImage.gameObject.SetActive(false);
                CarNumber = 0;
                finish = false;
                PlayerPrefs.SetInt("CarNumber", CarNumber);
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
