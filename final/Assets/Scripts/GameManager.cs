using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject healthCanvas;
    public GameObject deathCanvas;
    public GameObject player;


    void Update()
    {
        if (player == null)
            Death();
    }

    void Death()
    {
        healthCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
