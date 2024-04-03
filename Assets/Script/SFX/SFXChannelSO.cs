using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/SFX Channel")]
public class SFXChannelSO : ScriptableObject
{
    public UnityAction OnPunchSFXRequested;
    public UnityAction OnPunchHitSFXRequested;
    public UnityAction OnKatanaSFXRequested;
    public UnityAction OnKatanaHitSFXRequested;
    public UnityAction OnGunSFXRequested;
    public UnityAction OnGunHitSFXRequested;
    public AudioSource clip;

    public void RaisePunchSFXEvent()
    {
        OnPunchSFXRequested?.Invoke();
    }

    public void RaisePunchHitSFXEvent()
    {
        OnPunchHitSFXRequested?.Invoke();
    }

    public void RaiseKatanaSFXEvent()
    {
        OnKatanaSFXRequested?.Invoke();
    }

    public void RaiseKatanaHitSFXEvent()
    {
        OnKatanaHitSFXRequested?.Invoke();
    }

    public void RaiseGunSFXEvent()
    {
        OnGunSFXRequested?.Invoke();
    }

    public void RaiseGunHitSFXEvent()
    {
        OnGunHitSFXRequested?.Invoke();
    }
}
