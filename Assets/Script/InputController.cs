using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputController : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();
        int index = playerInput.playerIndex;
        playerController = playerControllers.FirstOrDefault(c => {
            return c.GetPlayerIndex() == index;
        });
    }

    public void OnMovementPerformed(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        playerController.OnMovementInput(movement);
    }
    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        bool jump = (context.ReadValue<float>() > 0.5f);
        playerController.OnJumpInput(jump);
    }
    public void OnFallPerformed(InputAction.CallbackContext context)
    {
       bool fall = (context.ReadValue<float>() > 0.5f);
        playerController.OnFallInput(fall);
    }

    public void OnSlideTogglePerformed(InputAction.CallbackContext context)
    {
        playerController.OnSlide();
    }
}
