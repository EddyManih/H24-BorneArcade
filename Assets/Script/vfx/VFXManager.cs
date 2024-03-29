using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
  public VFXChannelSO vfxChannel;
  public ParticleSystem[] landingVFX;
  public ParticleSystem[] slidingVFX;

  private List<ParticleSystem> activeVFX;

  private void Awake()
  {
    if (vfxChannel != null)
    {
      vfxChannel.OnLandingVFXRequested += PlayLandingVFX;
      vfxChannel.OnSlidingVFXRequested += PlaySlidingVFX;
      //vfxChannel.OnIsSlidingVFXRequested += MoveSlidingVFX;
    }

    activeVFX = new List<ParticleSystem>();
  }

    private void OnDestroy()
  {
    if (vfxChannel != null)
    {
      vfxChannel.OnLandingVFXRequested -= PlayLandingVFX;
      vfxChannel.OnSlidingVFXRequested -= PlaySlidingVFX;
      //vfxChannel.OnIsSlidingVFXRequested -= MoveSlidingVFX;
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
      activeVFX.Add(newVfx);
      newVfx.Play();
      Destroy(newVfx.gameObject, newVfx.main.duration);
    }
  }

//  private void MoveSlidingVFX(Vector3 position)
//  {
//    Vector3 offset = new(-0.5f, 0, 0);
//
//    for (int i = 0; i < activeVFX.Count; i++)
//    {
//      if (activeVFX[i] != null)
//      {
//        activeVFX[i].transform.position = position + offset;
//      }
//      else
//      {
//        activeVFX.RemoveAt(i);
//        i--;
//      }
//    }
//  }
}
