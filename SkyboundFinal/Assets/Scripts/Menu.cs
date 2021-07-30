using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    public DroneMovement drone;
    public InputField speedInputField;
    public InputField correctionInputField;
    public Dropdown courseDropDown;
    public DataManager dataManager;

    private void Awake() {
        Time.timeScale = 0;
        // dataManager = GameObject.GetComponent<DataManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        courseDropDown.onValueChanged.AddListener(delegate {dropdown(courseDropDown);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPress() {
        //set the time to 1 to allow the simulation to proceed normally
        Time.timeScale = 1;

        //turn the menu off
        dataManager.Disable();
    }

    public void dropdown(Dropdown dropdown) {
        int index = dropdown.value;
        switch (index)
        {
            //course 3
            case 0:
                drone.transform.position = new Vector3(828.1f,174.1f,1133f);
                break;
            //course 2
            case 1:
                drone.transform.position = new Vector3(288.7f,47.1f,243f);
                break;
            //course 3
            case 2:
                drone.transform.position = new Vector3(28.4f,12f,-46.7f);
                break;
            default:
                break;
        }
    }

    public void speed(string speed) {
        
        if (Single.TryParse(speedInputField.text, out float result))
        {
            var newSpeed = float.Parse(speedInputField.text);
            drone.forwardSpeed = newSpeed;   
        }
    }

    public void correction(string correctionC) {
        if (Single.TryParse(correctionInputField.text, out float result)) 
        {
            var newCoefficient = float.Parse(correctionInputField.text);
            drone.droneCorrectionConstant = newCoefficient;
        }
    }

    public void numObjects(int num) {
        //insert neumber of objects
    }
}
