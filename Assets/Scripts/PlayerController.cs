using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private CharacterController controller;
    private Transform camTransform;
    public float stamina = 5.0f;

    public float playerSpeed = 1.0f;
    public float sprintMultiplier = 2.0f;

    public float maxStamina = 5.0f;

    public RectTransform staminometer;

    public bool doStamina = true;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camTransform = Camera.main.transform;

        stamina = maxStamina;
    }

    void Update()
    {
        Vector2 input = inputManager.GetPlayerMovement();
        Vector3 move = new(input.x, 0f, input.y);
        if(doStamina)
        {
            if (inputManager.GetSprint() && stamina > 0 && move != Vector3.zero)
            {
                move *= sprintMultiplier;
                stamina -= Time.deltaTime;
                stamina = Mathf.Clamp(stamina, 0f, maxStamina);
            }
            else if (move == Vector3.zero)
            {
                stamina += Time.deltaTime * 1.5f;
                stamina = Mathf.Clamp(stamina, 0f, maxStamina);
            }

            staminometer.sizeDelta = new((565.96f / maxStamina) * stamina, staminometer.sizeDelta.y);
        }

        move = camTransform.forward * move.z + camTransform.right * move.x;
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
