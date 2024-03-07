using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public VFXChannelSO vfxChannel;

    private void Awake()
    {
        vfxChannel.OnCollisionVFXRequested += PlayCollisionVFX;
    }

    private void PlayCollisionVFX(Vector3 position)
    {
        Debug.Log("Playing collision VFX at " + position);
    }
}
