using UnityEngine;

public class VFXController : MonoBehaviour {
  public VFXChannelSO vfxChannel;
  public float groundCheckDistance = 0.1f;
  public LayerMask groundLayer;

  void Update() {
    Vector2 origin = transform.position;
    Vector2 direction = Vector2.down;
    RaycastHit2D hit =
        Physics2D.Raycast(origin, direction, groundCheckDistance, groundLayer);
    if (hit.collider != null) {
      Debug.Log("Landing");
      vfxChannel.RaiseLandingEvent(hit.point);
    }
  }
}
