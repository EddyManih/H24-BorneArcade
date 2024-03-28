using UnityEngine;

public class SFXController : MonoBehaviour {
  public SFXChannelSO sfxChannel;

  public void OnCollisionEnter2D() {
    Debug.Log("Collision detected");
    sfxChannel.RaisePlaySFXEvent();
  }
}
