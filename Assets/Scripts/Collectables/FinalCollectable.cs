using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalCollectable : TutorialCollectable
{
    public AudioSource normalSource;
    public AudioSource spookySource;
    public GameObject flashlight;
    public PlayerController playerController;

    public override void OnCollect()
    {
        playerController.stamina = playerController.maxStamina;
        normalSource.Stop();
        spookySource.Play();

        RenderSettings.ambientLight = Color.black;
        flashlight.SetActive(true);

        base.OnCollect();
    }
}
 