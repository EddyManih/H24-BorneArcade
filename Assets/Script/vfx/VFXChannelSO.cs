using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject {
  public UnityAction<Vector3> OnLandingVFXRequested;

  public void RaiseLandingEvent(Vector3 position) {
    if (OnLandingVFXRequested != null) {
      OnLandingVFXRequested.Invoke(position);
    }
  }
}
