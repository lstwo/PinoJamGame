using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPileResetter : MonoBehaviour
{
    public void StartReset()
    {
        StartCoroutine(resetAmmoPile());
    }

    public IEnumerator resetAmmoPile()
    {
        yield return new WaitForSeconds(15);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
