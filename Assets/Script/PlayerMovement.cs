using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 5f;
  private Rigidbody2D rb;
  private Vector2 movement;

  void Start() {}

  void Update() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    movement = new Vector2(horizontal, vertical).normalized;
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
  }
}
