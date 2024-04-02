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
    public ParticleSystem[] katanaVFX;
    public ParticleSystem[] gunVFX;

    private void Awake()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested += PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested += PlaySlidingVFX;
            vfxChannel.OnRunningVFXRequested += PlayRunningVFX;
            vfxChannel.OnKatanaVFXRequested += PlayKatanaVFX;
            vfxChannel.OnGunVFXRequested += PlayGunVFX;
        }

    }

    private void OnDestroy()
    {
        if (vfxChannel != null)
        {
            vfxChannel.OnLandingVFXRequested -= PlayLandingVFX;
            vfxChannel.OnSlidingVFXRequested -= PlaySlidingVFX;
            vfxChannel.OnRunningVFXRequested -= PlayRunningVFX;
            vfxChannel.OnKatanaVFXRequested -= PlayKatanaVFX;
            vfxChannel.OnGunVFXRequested -= PlayGunVFX;
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

    private void PlayRunningVFX(Vector3 position, bool flipped)
    {
        foreach (ParticleSystem vfx in runningVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            if (flipped)
            {
                newVfx.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }

    private void PlayKatanaVFX(Vector3 position, bool flipped)
    {
        foreach (ParticleSystem vfx in katanaVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            if (flipped)
            {
                newVfx.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }

    private void PlayGunVFX(Vector3 position, bool flipped)
    {
        foreach (ParticleSystem vfx in gunVFX)
        {
            ParticleSystem newVfx = Instantiate(vfx, position, Quaternion.identity);
            if (flipped)
            {
                newVfx.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            newVfx.Play();
            Destroy(newVfx.gameObject, newVfx.main.duration);
        }
    }
}
