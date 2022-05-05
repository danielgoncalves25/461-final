using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator canvas;
    public Animator settingsPanel;


    public void OpenSettings()
    {
        canvas.SetBool("isHidden", true);
        settingsPanel.SetBool("isHidden", true);
    }

    public void CloseSettings()
    {
        canvas.SetBool("isHidden", false);
        settingsPanel.SetBool("isHidden", false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");

    }

}
