using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    float gravity = 9.8f;

    [SerializeField]
    CharacterController controller;

    [SerializeField]
    Transform cameraTransform;

    Vector2 currentMovementVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        currentMovementVector = context.ReadValue<Vector2>();
    }

    void Move()
    {
        var z = cameraTransform.forward * currentMovementVector.y;
        var x = cameraTransform.right * currentMovementVector.x;
        Vector3 newVector = z + x;

        Vector3 movement = newVector * player.Speed * Time.fixedDeltaTime;
        movement.y = controller.isGrounded ? 0 : -gravity * Time.fixedDeltaTime;
        controller.Move(movement);
    }

    public void OnPreviousPower(InputAction.CallbackContext context)
    {
        player.PreviousPower();
    }

    public void OnNextPower(InputAction.CallbackContext context)
    {
        player.NextPower();
    }

    public void OnSetPower(InputAction.CallbackContext context)
    {
        var val = (int)context.ReadValue<float>();


        if (val == 0)
        {
            return;
        }

        Debug.LogWarning("Power: " + val);
        player.SetPowerIndex(val - 1);
    }

    public void OnPerformAction(InputAction.CallbackContext context)
    {
        player.UsePower();
    }
}
