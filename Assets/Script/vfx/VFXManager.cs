using UnityEngine;

public class VFXManager : MonoBehaviour {
  public VFXChannelSO vfxChannel;
  public ParticleSystem[] collisionVFX;
  public ParticleSystem[] landingVFX;

  private void Awake() {
    if (vfxChannel != null) {
      vfxChannel.OnLandingVFXRequested += PlayLandingVFX;
    }
  }

  private void OnDestroy() {
    if (vfxChannel != null) {
      vfxChannel.OnLandingVFXRequested -= PlayLandingVFX;
    }
  }

  private void PlayLandingVFX(Vector3 position) {
    foreach (ParticleSystem vfx in landingVFX) {
      ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
      newVfx.Play();
      Destroy(newVfx.gameObject, newVfx.main.duration);
    }
  }
}
