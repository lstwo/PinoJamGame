using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialCollectable : Collectable
{
    public string tutorialText;

    public GameObject tutorial;
    public TextMeshProUGUI tutorialTextObject;

    public override void OnCollect()
    {
        tutorialTextObject.text = tutorialText;
        tutorial.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        base.OnCollect();
    }
}
