using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/SFX Channel")]
public class SFXChannelSO : ScriptableObject {
  public UnityAction OnPlaySFXRequested;
  public AudioSource clip;

  public void RaisePlaySFXEvent() {
    if (OnPlaySFXRequested != null) {
      OnPlaySFXRequested.Invoke();
    }
  }
}
