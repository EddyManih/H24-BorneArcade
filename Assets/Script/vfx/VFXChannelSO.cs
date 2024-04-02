using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject
{
    public UnityAction<Vector3> OnLandingVFXRequested;
    public UnityAction<Vector3> OnSlidingVFXRequested;
    public delegate void RunningVFXEvent(Vector3 position, bool flipped);
    public RunningVFXEvent OnRunningVFXRequested;
    public delegate void KatanaVFXEvent(Vector3 position, bool flipped);
    public KatanaVFXEvent OnKatanaVFXRequested;
    public delegate void GunVFXEvent(Vector3 position, bool flipped);
    public GunVFXEvent OnGunVFXRequested;

    public void RaiseLandingEvent(Vector3 position)
    {
        OnLandingVFXRequested?.Invoke(position);
    }

    public void RaiseSlidingEvent(Vector3 position)
    {
        OnSlidingVFXRequested?.Invoke(position);
    }

    public void RaiseRunningEvent(Vector3 position, bool flipped)
    {
        OnRunningVFXRequested?.Invoke(position, flipped);
    }

    public void RaiseKatanaEvent(Vector3 position, bool flipped)
    {
        OnKatanaVFXRequested?.Invoke(position, flipped);
    }

    public void RaiseGunEvent(Vector3 position, bool flipped)
    {
        OnGunVFXRequested?.Invoke(position, flipped);
    }
}
