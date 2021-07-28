using UnityEngine;
using UnityEngine.UI;

/*
Script used for keeping track of time
*/

public class TimerText : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    public string tstring;

    void Start() {
        startTime = Time.time;
    }

    void Update(){
        if (!finished){
            float t = Time.time - startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            tstring = "Time Elapsed: " + minutes + ":" + seconds;
            timerText.text = tstring;
        }
    }
}
