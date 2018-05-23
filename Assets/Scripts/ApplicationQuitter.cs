using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
