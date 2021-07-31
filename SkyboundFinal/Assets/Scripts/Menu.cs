using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    public DroneMovement drone;
    public InputField detectionInputField;
    public InputField fSpeedInputField;
    public InputField tSpeedInputField;
    public Dropdown courseDropDown;
    public DataManager dataManager;
    public Canvas menu;

    private string[] detRadText = {
        "// Recommended Range (12-18)",
        "// Recommended Range (125-200)",
        "// Recommended Range (250-325)"
    };
    private string[] forSpeedText = {
        "// Recommended Range (2-8)",
        "// Recommended Range (6-12)",
        "// Recommended Range (12-20)"
    };
    private string[] turnSpeedText = {
        "// Recommended Range (8-16)",
        "// Recommended Range (12-20)",
        "// Recommended Range (24-48)"
    };
    //in form size, rayCastOffset, gravityCorrectionConstant
    private float[,] otherParams = {
        {.4f, 2.5f, 8f},
        {.33f, 6f, 3.5f},
        {1f, 9f, 7f}
    };
    private bool[] velocityCorrection = {false, true, true};


    void Awake() {
        Time.timeScale = 0;
        
        //Remove if not recording video
        QualitySettings.vSyncCount = 0;  
        Application.targetFrameRate = 45;
    }

    void Start()
    {
        courseDropDown.onValueChanged.AddListener(delegate {dropdown(courseDropDown);});
        changeRecommendedValues(0);

        //Add Event Listeners
        var temp = new InputField.SubmitEvent();
        temp.AddListener(detection);
        detectionInputField.onEndEdit = temp;

        var temp2 = new InputField.SubmitEvent();
        temp2.AddListener(fSpeed);
        fSpeedInputField.onEndEdit = temp2;

        var temp3 = new InputField.SubmitEvent();
        temp3.AddListener(tSpeed);
        tSpeedInputField.onEndEdit = temp3;
    }

    public void buttonPress() {
        //set the time to 1 to allow the simulation to proceed normally
        Time.timeScale = 1;

        //turn the menu off
        Disable();
    }

    public void dropdown(Dropdown dropdown) {
        int index = dropdown.value;
        switch (index)
        {
            //course 3
            case 0:
                drone.transform.position = new Vector3(28.4f,12f,-46.7f);
                changeRecommendedValues(0);
                break;
            //course 2
            case 1:
                drone.transform.position = new Vector3(288.7f,47.1f,243f);
                changeRecommendedValues(1);
                break;
            //course 3
            case 2:
                drone.transform.position = new Vector3(828.1f,174.1f,1133f);
                changeRecommendedValues(2);
                break;
            default:
                break;
        }
    }

    public void detection(string radius) {
        drone.detectionDist = float.Parse(radius);   
    }

    public void fSpeed(string speed) {
        drone.forwardSpeed = float.Parse(speed); 
    }

    public void tSpeed(string speed) {
        drone.droneCorrectionConstant = float.Parse(speed);
    }
    
    void changeRecommendedValues(int id){
        Text rv1 = GameObject.Find("RecVal1").GetComponent<Text>(); rv1.text = detRadText[id];
        Text rv2 = GameObject.Find("RecVal2").GetComponent<Text>(); rv2.text = forSpeedText[id];
        Text rv3 = GameObject.Find("RecVal3").GetComponent<Text>(); rv3.text = turnSpeedText[id];

        drone.droneSize = otherParams[id,0]; 
        drone.rayCastOffset = otherParams[id,1];
        drone.gravityCorrectionConstant = otherParams[id,2];
        drone.enableVelocityControlling = velocityCorrection[id];
        Debug.Log(drone.enableVelocityControlling);
    }

    public void Disable()
    {
        menu.enabled = false;
    }
    
}
