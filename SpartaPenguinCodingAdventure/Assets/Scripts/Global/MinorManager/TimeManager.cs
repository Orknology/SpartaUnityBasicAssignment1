using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timetext;

    private void FixedUpdate()
    {
        GetCurrentDate();
    }
    private void GetCurrentDate()
    {
        string time = DateTime.Now.ToString(("MM-dd HH:mm:ss tt"));
        timetext.text = time;
    }
}
