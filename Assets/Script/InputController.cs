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
        // Pour debug les input devices
        /* 
        foreach (InputDevice device in playerInput.devices)
        {
            Debug.Log(device.ToString());
            Debug.Log(device.ToString().Equals("HID::DragonRise Inc.   Generic   USB  Joystick  :/DragonRise Inc.   Generic   USB  Joystick  "));
        }
        */
        playerController = playerControllers.FirstOrDefault(player => {
            // Pour la borne
            // ----------------------------------------
            if (playerInput.devices[0].ToString().Equals("HID::DragonRise Inc.   Generic   USB  Joystick  :/DragonRise Inc.   Generic   USB  Joystick  ")) return player.GetPlayerIndex() == 0;
            else return player.GetPlayerIndex() == 1;
            // ----------------------------------------

            // Pour tester avec le clavier ou des manettes
            // ----------------------------------------
            // return player.GetPlayerIndex() == index;
            // ----------------------------------------
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
