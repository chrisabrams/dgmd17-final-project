using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }
}
