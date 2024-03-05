using UnityEngine;

public class EffectsController : MonoBehaviour {
  public ParticleSystem[] particleSystems;

  void OnCollisionEnter2D(Collision2D other) { PlayEffects(); }

  private void PlayEffects() {
    Vector3 position = transform.position;
    foreach (ParticleSystem particleSystem in particleSystems) {
      ParticleSystem newParticleSystem =
          Instantiate(particleSystem, position, Quaternion.identity);
      newParticleSystem.Play();
      Destroy(newParticleSystem.gameObject, newParticleSystem.main.duration);
    }
  }
}
