using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public virtual void OnCollect()
    {
        Destroy(gameObject);
    }
}
