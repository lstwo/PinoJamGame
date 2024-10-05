using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static bool checkpointMode = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if(PlayerPrefs.GetInt("Ending") == 1)
        {
            SceneManager.LoadScene("The Return");
        }
    }

    public void ToggleCheckpointMode(bool b)
    {
        checkpointMode = b;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ToggleWindowed(bool b)
    {
        Screen.fullScreen = b;
    }
}
