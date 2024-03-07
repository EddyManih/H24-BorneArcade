using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public VFXChannelSO vfxChannel;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        vfxChannel.RaiseCollisionEvent(collision.contacts[0].point);
    }
}
