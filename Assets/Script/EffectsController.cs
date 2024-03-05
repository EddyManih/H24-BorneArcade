using UnityEngine;

public class EffectsController : MonoBehaviour {
  public ParticleSystem[] particleSystems;

  public void PlayEffects() {
    foreach (ParticleSystem particleSystem in particleSystems) {
      particleSystem.Play();
    }
  }
}
