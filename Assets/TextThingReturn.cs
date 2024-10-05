using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextThingReturn : MonoBehaviour
{
    public GameObject[] texts;

    private int index = 0;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            texts[index].SetActive(false);
            index++;

            if(index == texts.Length)
            {
                SceneManager.LoadScene(1);
                return;
            }

            texts[index].SetActive(true);
        }
    }
}
