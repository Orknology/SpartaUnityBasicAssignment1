using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class ExitButton : MonoBehaviour
{
    public GameObject ExitingCanvas;

    public void BtnClickedExit()
    {
        Thread.Sleep(200);
        ExitingCanvas.SetActive(false);
        if (Time.timeScale < 1.0f)
            Time.timeScale = 1.0f;
    }
}
