using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
This script is used to display the time at the end of the screen.

TODO: Once we add more levels, it would be nice to have a list of all the times at the end (take a look at DataManager.cs)
*/

public class DisplayTimeEndScreen : MonoBehaviour
{
    public Text timerText;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "EndScreen"){
            DataManager rf = GameObject.Find("DataManager").GetComponent<DataManager>();
            timerText.text = rf.timeElapsed;
        }
    }
}
