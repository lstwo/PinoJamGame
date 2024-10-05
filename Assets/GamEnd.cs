using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamEnd : MonoBehaviour
{
    IEnumerator Start()
    {
        if(PlayerPrefs.GetInt("Ending") == 0)
            PlayerPrefs.SetInt("Ending", 1);
        else
            PlayerPrefs.SetInt("Ending", 2);

        yield return new WaitForSeconds(7.4f);
        Application.Quit();
    }
}
