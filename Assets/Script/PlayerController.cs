using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Déclaration des constantes
    private static readonly Vector2 FlipRotation = new Vector3(0, 180);

    private float _Timer;
    private float _LastHorizontal;

    // Valeurs exposées
    [SerializeField]
    float MoveSpeed = 5.0f;

    [SerializeField]
    float JumpForce = 9.0f;

    [SerializeField]
    LayerMask WhatIsGround;
    Animator _Anim { get; set; }
    float _movementInput;
    bool _Sliding;
    bool movementEnabled {get; set; }
    Rigidbody2D _Rb { get; set; }
    bool _Grounded { get; set; }
    bool _Flipped { get; set; }

    void Awake() {
        _Anim = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
        movementEnabled = true;
        _Sliding = false;
        _Timer = 0.0f;
        _LastHorizontal = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        _movementInput = 0.0f;
        _Grounded = false;
        _Flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = movementEnabled ? _movementInput * MoveSpeed : 0;
        HorizontalMove(horizontal);
        FlipCharacter(horizontal);
        _Timer += Time.deltaTime;
    }

    // Gère le mouvement horizontal
    void HorizontalMove(float horizontal)
    {
        if (!_Sliding)
        {
            _Rb.velocity = new Vector2(horizontal, _Rb.velocity.y);
            _Anim.SetFloat("MoveSpeed", Mathf.Abs(horizontal));
        }
        
        if (_Sliding)
        {
            _Rb.velocity = new Vector2(_LastHorizontal, _Rb.velocity.y);

            if (_Timer > 0.5f)
            {
                movementEnabled = true;
                _Sliding = false;
                _Anim.SetBool("Sliding", _Sliding);
            }
        }
    }

    void FlipCharacter(float horizontal)
    {
        if (horizontal < 0 && !_Flipped)
        {
            _Flipped = true;
            transform.Rotate(FlipRotation);
        }
        else if (horizontal > 0 && _Flipped)
        {
            _Flipped = false;
            transform.Rotate(-FlipRotation);
        }
    }

    // Collision avec le sol
    void OnCollisionEnter2D(Collision2D coll)
    {
        // On s'assure de bien être en contact avec le sol
        if ((WhatIsGround & (1 << coll.gameObject.layer)) == 0)
            return;

        // Évite une collision avec le plafond
        if (coll.relativeVelocity.y > 0)
        {
            _Grounded = true;
            _Anim.SetBool("Grounded", _Grounded);
        }
    }

    public void OnMovementInput(float movementInput)
    {
        _movementInput = movementInput;
    }

    public void OnSlide()
    {
        if (Mathf.Abs(_movementInput) == 1)
        {
            _LastHorizontal = _movementInput * MoveSpeed;
            movementEnabled = false;
            _Sliding = true;
            _Timer = 0.0f;
            _Anim.SetBool("Sliding", _Sliding);
        }
    }
}
