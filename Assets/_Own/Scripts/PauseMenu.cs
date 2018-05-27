using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : SelectCar
{
    public GameObject PauseMenuCanvas;

    private void Start()
    {
        CarNumber = PlayerPrefs.GetInt("CarNumber");
    }

    public void ContinueGame()
    {
        CarController.PauseGame = false;
        PauseMenuCanvas.gameObject.SetActive(false);
        Cars[CarNumber].GetComponent<CarController>().enabled = true;
        Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        CarController.PauseGame = false;
        PauseMenuCanvas.gameObject.SetActive(false);
        Cars[CarNumber].GetComponent<CarController>().enabled = true;
        Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;

        SceneManager.LoadScene(2);
    }

    public void BackToMainMenu()
    {
        CarController.PauseGame = false;
        PauseMenuCanvas.gameObject.SetActive(false);
        Cars[CarNumber].GetComponent<CarController>().enabled = true;
        Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
        CarNumber = 0;
        PlayerPrefs.SetInt("CarNumber", CarNumber);

        SceneManager.LoadScene(0);
    }

    public void BackToCarSelection()
    {
        CarController.PauseGame = false;
        PauseMenuCanvas.gameObject.SetActive(false);
        Cars[CarNumber].GetComponent<CarController>().enabled = true;
        Cars[CarNumber].GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1;
        CarNumber = 0;
        PlayerPrefs.SetInt("CarNumber", CarNumber);

        SceneManager.LoadScene(1);
    }
}
