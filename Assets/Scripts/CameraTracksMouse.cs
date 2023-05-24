using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTracksMouse : MonoBehaviour
{
    [SerializeField]
    Camera cameraToUse;

    [SerializeField]
    Vector2 sensitivity;

    float pitchX;
    float pitchY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void HandleLook(InputAction.CallbackContext context)
    {
        var mousePos = context.ReadValue<Vector2>();
        pitchX -= mousePos.y * sensitivity.y;
        pitchY -= -mousePos.x * sensitivity.y;

        pitchX = Mathf.Clamp(pitchX, -90.0f, 90.0f);

        cameraToUse.transform.localEulerAngles = (Vector3.right * pitchX) + (Vector3.up * pitchY);

        //transform.Rotate(Vector3.up * mousePos.x * sensitivity.x);
    }
}
