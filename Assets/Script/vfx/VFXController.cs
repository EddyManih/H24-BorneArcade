using UnityEngine;

public class VFXController : MonoBehaviour {
  public VFXChannelSO vfxChannel;

  public void OnCollisionEnter2D(Collision2D collision) {
    Vector2 collisionCenter = GetCollisionCenter(collision);
    vfxChannel.RaiseCollisionEvent(collisionCenter);
  }

  private Vector2 GetCollisionCenter(Collision2D collision) {
    Vector2 center = Vector2.zero;
    foreach (ContactPoint2D contact in collision.contacts) {
      center += contact.point;
    }
    center /= collision.contacts.Length;
    return center;
  }
}
