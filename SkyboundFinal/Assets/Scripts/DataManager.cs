using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Hold any data between levels that other scripts can use

TODO: Once we get more levels, store all the times and display them at the end
*/

public class DataManager : MonoBehaviour
{
    public string timeElapsed;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update(){
        try{
            TimerText rf = GameObject.Find("TimerText").GetComponent<TimerText>();
            timeElapsed = rf.tstring;
        }
        catch(Exception e){
        }
    }
}
