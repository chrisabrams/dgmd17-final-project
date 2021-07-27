using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string timeElapsed;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }

    void LateUpdate(){
        TimerText rf = GameObject.Find("TimerText").GetComponent<TimerText>();
        timeElapsed = rf.tstring;
    }
}
