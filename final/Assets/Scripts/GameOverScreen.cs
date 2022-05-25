using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public void LoadStartScene() 
    {
        SceneManager.LoadScene(1);
    }
     public void LoadMainScene() 
    {
        SceneManager.LoadScene(0);
    }

}

