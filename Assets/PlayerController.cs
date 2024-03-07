using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Valeurs exposées
    [SerializeField]
    float MoveSpeed = 5.0f;

    [SerializeField]
    float JumpForce = 9.0f;

    [SerializeField]
    LayerMask WhatIsGround;
    Animator _Anim { get; set; }
    bool mouvementEnabled {get; set; }
    Rigidbody2D _Rb { get; set; }

    void Awake() {
        _Anim = GetComponent<Animator>();
        _Rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = mouvementEnabled ? Input.GetAxis("Horizontal") * MoveSpeed : 0;
        HorizontalMove(horizontal);
    }

    // Gère le mouvement horizontal
    void HorizontalMove(float horizontal)
    {
        _Rb.velocity = new Vector3(_Rb.velocity.x, _Rb.velocity.y, horizontal);
        //_Anim.SetFloat("MoveSpeed", Mathf.Abs(horizontal));
    }
}
