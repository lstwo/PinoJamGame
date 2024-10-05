using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.ammo++;
            GameManager.Instance.collectablesText.text = "Ammo: " + GameManager.Instance.ammo;
            transform.parent.GetComponent<AmmoPileResetter>().StartReset();
            gameObject.SetActive(false);
        }
    }
}
