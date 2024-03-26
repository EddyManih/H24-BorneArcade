using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction HorizontalMovement;
    [SerializeField] private InputAction JumpInput;
    [SerializeField] private InputAction FallInput;
    [SerializeField] private InputAction SlideToggle;
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        // Logic when movement key is pressed
        HorizontalMovement.performed += OnMovementPerformed;
        // Logic when movement key is released
        HorizontalMovement.canceled  += OnMovementPerformed;

        //Logic when slide toggle is performed
        SlideToggle.performed += OnSlideTogglePerformed;

        JumpInput.performed += OnJumpPerformed;
        // Logic when movement key is released
        JumpInput.canceled  += OnJumpPerformed;

        FallInput.performed += OnFallPerformed;
        // Logic when movement key is released
        FallInput.canceled  += OnFallPerformed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        playerController.OnMovementInput(movement);
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        bool jump = (context.ReadValue<float>() > 0.5f);
        playerController.OnJumpInput(jump);
    }
    private void OnFallPerformed(InputAction.CallbackContext context)
    {
       bool fall = (context.ReadValue<float>() > 0.5f);
        playerController.OnFallInput(fall);
    }

    private void OnSlideTogglePerformed(InputAction.CallbackContext context)
    {
        playerController.OnSlide();
    }

    private void OnEnable()
    {
        HorizontalMovement.Enable();
        SlideToggle.Enable();
        JumpInput.Enable();
        FallInput.Enable();
    }

    private void OnDisable()
    {
        HorizontalMovement.Disable();
        SlideToggle.Disable();
        JumpInput.Enable();
        FallInput.Enable();
    }
}
