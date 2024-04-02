using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/SFX Channel")]
public class SFXChannelSO : ScriptableObject
{
    public UnityAction OnPunchSFXRequested;
    public UnityAction OnPunchHitSFXRequested;
    public AudioSource clip;

    public void RaisePunchSFXEvent()
    {
        OnPunchSFXRequested?.Invoke();
    }

    public void RaisePunchHitSFXEvent()
    {
        OnPunchHitSFXRequested?.Invoke();
    }
}
