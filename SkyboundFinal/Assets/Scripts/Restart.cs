using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Script for restart button on EndScreen
*/

public class Restart : MonoBehaviour
{
    public Button restartBtn;

    void Start()
    {
        restartBtn.onClick.AddListener(restartGame);
    }

    void restartGame()
    {
        SceneManager.LoadScene("Simulation", LoadSceneMode.Single);

        //unnecessary to move the drone back as the initial scene has the 
        //drone set to the starting position

        // MoveDrone(31.1f, -0.88f, -38.65f); // Course 1
        // MoveDrone(259.4f, 39.7f, 265f); // Course 2
        // MoveDrone(828.1f, 174.1f, 1133f);
    }

    // void MoveDrone(float x, float y, float z) {
    //     rb.transform.position = new Vector3(x, y, z);
    // }
}
