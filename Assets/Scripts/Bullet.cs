using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
