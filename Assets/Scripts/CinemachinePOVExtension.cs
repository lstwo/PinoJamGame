using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float verticalSpeed = 10f;

    [SerializeField]
    private float clampAngle = 80f;

    private InputManager inputManager;
    private Vector3 startingRotation;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (inputManager == null) return;
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x * horizontalSpeed / 165 * Time.timeScale;
                startingRotation.y += -deltaInput.y * verticalSpeed / 165 * Time.timeScale;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

    protected override void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputManager = InputManager.Instance;
        base.Awake();
    }
}
