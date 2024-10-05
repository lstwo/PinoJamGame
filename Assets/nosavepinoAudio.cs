using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nosavepinoAudio : MonoBehaviour
{
    void Awake()
    {
        if(PlayerPrefs.GetInt("Ending") != 1)
        {
            GetComponent<AudioSource>().Stop();
            Destroy(gameObject);
        }
        if(PlayerPrefs.GetInt("Ending") == 1)
        {
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("Ending", 2);
        }
    }
}
