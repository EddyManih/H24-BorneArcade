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

  private void PlaySFX() {
    foreach (AudioClip clip in sfx) {
      GameObject sfxObject = new GameObject("sfxObject");
      AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
      audioSource.clip = clip;
      audioSource.volume = volumeScale;
      audioSource.Play();
      Destroy(sfxObject, clip.length);
    }
  }
}
