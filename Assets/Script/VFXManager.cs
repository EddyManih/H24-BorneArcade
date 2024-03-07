using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public VFXChannelSO vfxChannel;
    public ParticleSystem[] collisionVFX;

    private void Awake()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnCollisionVFXRequested += PlayCollisionVFX;
        }
    }

    private void OnDestroy()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnCollisionVFXRequested -= PlayCollisionVFX;
        }
    }

    private void PlayCollisionVFX(Vector3 position)
    {
        foreach (ParticleSystem vfx in collisionVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }
}
