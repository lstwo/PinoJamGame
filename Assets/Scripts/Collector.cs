using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collector : MonoBehaviour
{
    public LayerMask mask;
    public GameObject ammoPrefab;
    public float shootForce;

    private void Awake()
    {
        InputManager.Instance.clickAction.performed += Collect;
        InputManager.Instance.clickAction.performed += Shoot;
    }

    void Collect(InputAction.CallbackContext ctx)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 5.0f, mask))
        {
            if(GameManager.Instance.collectables.Contains(hit.collider.gameObject))
            {
                GameManager.Instance.Collect(hit.collider.gameObject);
            }
        }
    }

    void Shoot(InputAction.CallbackContext ctx)
    {
        if(GameManager.Instance.ammo > 0)
        {
            GameObject go = Instantiate(ammoPrefab, transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootForce, ForceMode.Impulse);
            GameManager.Instance.ammo--;
            GameManager.Instance.collectablesText.text = "Ammo: " + GameManager.Instance.ammo;
        }
    } 
}