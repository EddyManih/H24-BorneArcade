using UnityEngine;

public class SFXManager : MonoBehaviour {
  public SFXChannelSO sfxChannel;
  public AudioClip[] sfx;
  public float volumeScale = 1f;

  private void Awake() {
    if (sfxChannel != null) {
      sfxChannel.OnPlaySFXRequested += PlaySFX;
    }
  }

  private void PlaySFX(AudioSource sfxSource) {
    foreach (AudioClip clip in sfx) {
      sfxSource.PlayOneShot(clip, volumeScale);
    }
  }
}
