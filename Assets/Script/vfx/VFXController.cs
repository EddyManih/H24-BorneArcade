using UnityEngine;

public class VFXController : MonoBehaviour {
  public VFXChannelSO vfxChannel;

  private int _floorLayer = 3;

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.layer == _floorLayer) {
      Vector2 collisionCenter = GetCollisionCenter(collision);
      vfxChannel.RaiseLandingEvent(collisionCenter);
    }
  }

  private Vector3 GetCollisionCenter(Collision2D collision) {
    Vector2 center = Vector2.zero;
    foreach (ContactPoint2D contact in collision.contacts) {
      center += contact.point;
    }
    return center / collision.contacts.Length;
  }
}
