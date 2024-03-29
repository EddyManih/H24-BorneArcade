using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Déclaration des constantes
    private static readonly Vector2 FlipRotation = new Vector3(0, 180);

    // Valeurs privées
    private UnityEvent flipEvent;

    // Valeurs exposées
    [SerializeField] PlayerIndicator playerIndicator;
    [SerializeField] float MoveSpeed = 5.0f;

    [SerializeField] float JumpForce = 9.0f;

    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] HealthManagerSO healthManagerPrefab;

    // Call the healthManagerSO when the player loses health
    [System.NonSerialized] public HealthManagerSO healthManagerSO;

    Animator _Anim { get; set; }
    float _movementInput;

    bool _movementEnabled {get; set; }
    Rigidbody2D _Rb { get; set; }
    bool _Grounded { get; set; }
    bool _Flipped { get; set; }

    void Awake() {
        _Anim = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
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
    }

    // Update is called once per frame
    void Update()
    {
        
        var horizontal = _movementEnabled ? _movementInput * MoveSpeed : 0;
        HorizontalMove(horizontal);
        FlipCharacter(horizontal);
        
    }

    // Gère le mouvement horizontal
    void HorizontalMove(float horizontal)
    {
        _Rb.velocity = new Vector2(horizontal, _Rb.velocity.y);
        _Anim.SetFloat("MoveSpeed", Mathf.Abs(horizontal));
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
            _Grounded = true;
            _Anim.SetBool("Grounded", _Grounded);
        }
    }

    void DiedEvent()
    {
        Destroy(gameObject);
    }

    public void OnMovementInput(float movementInput)
    {
        _movementInput = movementInput;
    }

    public void DisableMovement()
    {
        _movementEnabled = false;

    }
}
