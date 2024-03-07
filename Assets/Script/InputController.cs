using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction left;
    [SerializeField] private InputAction right;
    // Start is called before the first frame update
    void Start()
    {
        // Logic when left movement key is pressed
        left.performed += context => Debug.Log("Left Key Pressed");
        // Logic when left movement key is released
        left.canceled += context => Debug.Log("Left Key Released");
        // Logic when right movement key is pressed
        right.performed += context => Debug.Log("Right Key Pressed");
        // Logic when right movement key is pressed
        right.canceled += context => Debug.Log("Right Key Released");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
