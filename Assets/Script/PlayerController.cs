using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
  // Déclaration des constantes
  private static readonly Vector2 FlipRotation = new Vector3(0, 180);

    private float _Timer;
    private float _LastHorizontal;
    private UnityEvent flipEvent;

    // Valeurs exposées
    [SerializeField] private int playerIndex;
    [SerializeField] private PlayerIndicator playerIndicator;
    [SerializeField] private float MoveSpeed = 5.0f;
    [SerializeField] private float JumpForce = 9.0f;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private PlayerAttack playerAttack;

    // Call the healthManagerSO when the player loses health
    [SerializeField] private HealthManagerSO healthManagerPrefab;
    [System.NonSerialized] public HealthManagerSO healthManagerSO;

    private Animator _Anim { get; set; }
    private float _movementInput;
    private bool _movementEnabled {get; set; }
    private Rigidbody2D _Rb { get; set; }
    private bool _IsDoubleJump {get; set;}
    private bool _IsJump {get; set;}
    private bool _jumpInput;
    private bool _fallInput;

    public bool _Flipped { get; private set; }
    public bool _Grounded { get; private set; }
    public bool _Sliding { get; private set; }

    void Awake() {
        _Anim = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
        _Sliding = false;
        _Timer = 0.0f;
        _LastHorizontal = 0.0f;
        flipEvent = new UnityEvent();
        flipEvent.AddListener(playerIndicator.FlipIndicator);
        healthManagerSO = Instantiate<HealthManagerSO>(healthManagerPrefab);
        healthManagerSO.DiedEvent.AddListener(DiedEvent);
    }

    void Start()
    {
        _movementEnabled = true;
        _movementInput = 0.0f;
        _Grounded = false;
        _Flipped = false;
        _IsDoubleJump = false;
        _IsJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_Grounded);
        var horizontal = _movementEnabled ? _movementInput * MoveSpeed : 0;
        if( _jumpInput){
            _jumpInput = false;
            Jump();
        }
        if(_fallInput){
            Fall();
        }
        HorizontalMove(horizontal);
        FlipCharacter(horizontal);
        _Timer += Time.deltaTime;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    void Jump()
    {
        if (_Grounded && !_IsJump)
        {
            _Rb.velocity = new Vector2(_Rb.velocity.x, JumpForce);
            //_Grounded = false;
            _IsJump = true;
            StopSliding();
            _Anim.SetTrigger("Jump");
            _Anim.SetBool("Grounded", false);
            _jumpInput = false; // Reset jump input
        }
        else if (!_Grounded && !_IsDoubleJump && _IsJump)
        {
            _Rb.velocity = new Vector2(_Rb.velocity.x, JumpForce);
            _IsJump = false;
            _IsDoubleJump = true;
            _Anim.SetTrigger("DoubleJump");
            _jumpInput = false; // Reset jump input
        }
    }
    void Fall()
    {
        if(!_Grounded){
            _Rb.velocity = new Vector2(_Rb.velocity.x, -JumpForce);
        }
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
                StopSliding();
            }
        }
    }

    void StopSliding()
    {
        _movementEnabled = true;
        _Sliding = false;
        _Anim.SetBool("Sliding", _Sliding);
    }

    void FlipCharacter(float horizontal)
    {
        if (horizontal < 0 && !_Flipped)
        {
            _Flipped = true;
            transform.Rotate(FlipRotation);
            flipEvent.Invoke();
        }
        else if (horizontal > 0 && _Flipped)
        {
            _Flipped = false;
            transform.Rotate(-FlipRotation);
            flipEvent.Invoke();
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
             _IsDoubleJump = false;
            _IsJump = false;
            _Grounded = true;
            _Anim.SetBool("Grounded", _Grounded);
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        // On s'assure de ne pas etre en contact avec sol
        if ((WhatIsGround & (1 << coll.gameObject.layer)) == 0)
            return;

        _Grounded = false;

    }

    void DiedEvent()
    {
        Destroy(gameObject);
    }

    public void OnMovementInput(float movementInput)
    {
        _movementInput = movementInput;
    }

     public void OnJumpInput(bool jumpInput)
    {
        _jumpInput = jumpInput;
    }

     public void OnFallInput(bool fallInput)
    {
        _fallInput = fallInput;
    }

    public void OnSlide()
    {
        if (Mathf.Abs(_movementInput) == 1 && !_Sliding)
        {
            _LastHorizontal = _movementInput * MoveSpeed;
            _movementEnabled = false;
            _Sliding = true;
            _Timer = 0.0f;
            _Anim.SetBool("Sliding", _Sliding);
        }
    }

    void OnKatanaHit()
    {
        healthManagerSO.DamageTaken(playerAttack.katanaDamage);
    }

    void OnPunchHit()
    {
        healthManagerSO.DamageTaken(playerAttack.punchDamage);
    }

    public void DisableMovement()
    {
        _movementEnabled = false;
    }
}
