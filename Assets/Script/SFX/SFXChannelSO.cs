using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/SFX Channel")]
public class SFXChannelSO : ScriptableObject {
  public UnityAction<AudioSource> OnPlaySFXRequested;

  public void RaisePlaySFXEvent(AudioSource clip) {
    if (OnPlaySFXRequested != null) {
      OnPlaySFXRequested.Invoke(clip);
    }
  }
}
