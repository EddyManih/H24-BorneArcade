using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject {
  public UnityAction<Vector3> OnCollisionVFXRequested;

  public void RaiseCollisionEvent(Vector3 position) {
    if (OnCollisionVFXRequested != null) {
      OnCollisionVFXRequested.Invoke(position);
    }
  }
}
