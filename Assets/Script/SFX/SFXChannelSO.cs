using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/SFX Channel")]
public class SFXChannelSO : ScriptableObject {
  public UnityAction<AudioClip> OnPlaySFXRequested;

  public void RaisePlaySFXEvent(AudioClip clip) {
    if (OnPlaySFXRequested != null) {
      OnPlaySFXRequested.Invoke(clip);
    }
  }
}
