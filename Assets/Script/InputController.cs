using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction HorizontalMovement;
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        // Logic when movement key is pressed
        HorizontalMovement.performed += OnMovementPerformed;
        // Logic when movement key is released
        HorizontalMovement.canceled  += OnMovementPerformed;

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

    private void OnEnable()
    {
        HorizontalMovement.Enable();
    }

    private void OnDisable()
    {
        HorizontalMovement.Disable();
    }
}
