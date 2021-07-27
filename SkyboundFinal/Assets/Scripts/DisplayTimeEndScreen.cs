using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeEndScreen : MonoBehaviour
{
    public Text timerText;

    void Start()
    {
        DataManager rf = GameObject.Find("DataManager").GetComponent<DataManager>();
        timerText.text = rf.timeElapsed;
    }

  
}
