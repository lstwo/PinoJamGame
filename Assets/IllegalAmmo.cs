using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllegalAmmo : MonoBehaviour
{
    public FISHBoss fish;
    public GameObject ammo;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Ending") != 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fish.startTrueEnd();
            GameManager.Instance.ammo = int.MaxValue;
            GameManager.Instance.collectablesText.text = "Ammo: " + GameManager.Instance.ammo;
            Destroy(gameObject);
            Destroy(ammo);
        }
    }
}
