using UnityEngine;

public class SFXController : MonoBehaviour {
  public SFXChannelSO sfxChannel;

  public void OnCollisionEnter2D(AudioSource sfxSource) {
    sfxChannel.RaisePlaySFXEvent(sfxSource);
  }
}
