using UnityEngine;

public class SFXController : MonoBehaviour {
  public SFXChannelSO sfxChannel;

  public void OnCollisionEnter2D(Collision2D collision) {
    sfxChannel.RaisePlaySFXEvent();
  }
}
