using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 5f;
  private Rigidbody2D rb;
  private Vector2 movement;

  void Start() { rb = GetComponent<Rigidbody2D>(); }

  void Update() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    movement = new Vector2(horizontal, vertical).normalized;
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
  }
}
