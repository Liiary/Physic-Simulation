using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimeText;
    private float startTime;
    private bool endTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (!endTime)
        {
            float timer = Time.time - startTime;

            string seconds = (timer % 60).ToString("f3");
            string minutes = ((int)timer / 60).ToString();

            TimeText.text = minutes + ":" + seconds;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            endTime = true;
        }
    }
}
