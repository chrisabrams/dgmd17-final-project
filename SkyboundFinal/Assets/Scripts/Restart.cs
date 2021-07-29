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

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        restartBtn.onClick.AddListener(restartGame);
    }

    void restartGame()
    {
        SceneManager.LoadScene("Simulation", LoadSceneMode.Single);

        // MoveDrone(31.1f, -0.88f, -38.65f); // Course 1
        MoveDrone(259.4f, 39.7f, 265f); // Course 1
    }

    void MoveDrone(float x, float y, float z) {
        rb.transform.position = new Vector3(x, y, z);
    }
}
