using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public VFXChannelSO vfxChannel;
    public ParticleSystem[] landingVFX;
    public ParticleSystem[] slidingVFX;

    private void Awake()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested += PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested += PlaySlidingVFX;
        }

    }

    private void OnDestroy()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested -= PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested -= PlaySlidingVFX;
        }
    }

    private void PlayLandingVFX(Vector3 position)
    {
        foreach (ParticleSystem vfx in landingVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }

    private void PlaySlidingVFX(Vector3 position)
    {
        foreach (ParticleSystem vfx in slidingVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }
}
