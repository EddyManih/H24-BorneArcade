using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public VFXChannelSO vfxChannel;
    public ParticleSystem[] landingVFX;
    public ParticleSystem[] slidingVFX;
    public ParticleSystem[] runningVFX;

    private void Awake()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested += PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested += PlaySlidingVFX;
            vfxChannel.OnRunningVFXRequested += PlayRunningVFX;
        }

    }

    private void OnDestroy()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested -= PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested -= PlaySlidingVFX;
            vfxChannel.OnRunningVFXRequested -= PlayRunningVFX;
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

    private void PlayRunningVFX(Vector3 position)
    {
        foreach (ParticleSystem vfx in runningVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }
}
