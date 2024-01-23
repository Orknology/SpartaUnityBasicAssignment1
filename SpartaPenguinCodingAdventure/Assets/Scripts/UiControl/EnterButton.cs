using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnterButton : MonoBehaviour
{
    public GameObject EnteringCanvas;

    public void BtnClickedEnter()
    {
        Thread.Sleep(200);
        EnteringCanvas.SetActive(true);
        if (Time.timeScale > 0.0f)
            Time.timeScale = 0.0f;
    }
}
