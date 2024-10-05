using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class FinalExit : MonoBehaviour
{
    public AudioSource normalAudio;
    public AudioSource preBossAudio;
    public AudioSource bossAudio;
    public Transform fishTransform;
    public GameObject mainCam;
    public GameObject focusCam;
    public Transform bossSpawnTransform;
    public FISHBoss fishBoss;
    public GameObject UI;
    public TextMeshProUGUI collectedText;
    public Volume postProcessing;
    public VolumeProfile bossPostProcessing;
    public GameManager gameManager;
    public GameObject Ammo;
    public PlayerController playerController;
    public TextMeshProUGUI staminometerText;
    public RectTransform staminometer;

    private Vector3 camPos = Vector3.zero;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            preBossAudio.Play();
            StartCoroutine(bossfightAnimation());
        }
    }

    IEnumerator bossfightAnimation()
    {
        fishBoss.GetComponent<NavMeshAgent>().enabled = false;
        fishBoss.enabled = false;
        UI.SetActive(false);
        collectedText.text = "Ammo: 0";
        playerController.enabled = false;

        normalAudio.Stop();
        focusCam.transform.position = mainCam.transform.position;
        focusCam.SetActive(true);
        mainCam.SetActive(false);

        staminometer.sizeDelta = new(565.96f, staminometer.sizeDelta.y);

        float timer = 0;
        while(timer < 19.117f)
        {
            timer += Time.deltaTime;

            focusCam.transform.position = Vector3.Lerp(focusCam.transform.position, fishTransform.position + Vector3.up / 1.5f + Vector3.forward * 3, (timer / 19.117f) * Time.deltaTime / 2);
            focusCam.transform.LookAt(fishTransform);

            yield return null;
        }

        postProcessing.profile = bossPostProcessing;
        RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f);

        playerController.doStamina = false;

        focusCam.SetActive(false);
        mainCam.SetActive(true);

        Ammo.SetActive(true);

        UI.SetActive(true);
        fishTransform.position = bossSpawnTransform.position;
        playerController.enabled = true;
        fishBoss.GetComponent<NavMeshAgent>().enabled = true;
        fishBoss.enabled = true;
        staminometerText.text = "FISH HP";

        playerController.playerSpeed = 5;
        playerController.sprintMultiplier = 1;

        bossAudio.Play();

        Destroy(this);
    }
}
