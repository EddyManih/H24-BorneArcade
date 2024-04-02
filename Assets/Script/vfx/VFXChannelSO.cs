using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject
{
    public UnityAction<Vector3> OnLandingVFXRequested;
    public UnityAction<Vector3> OnSlidingVFXRequested;
    public delegate void RunningVFXEvent(Vector3 position, bool direction); //Running right is true, running left is false
    public RunningVFXEvent OnRunningVFXRequested;
    public delegate void KatanaVFXEvent(Vector3 position, bool direction); //Katana right is true, katana left is false
    public KatanaVFXEvent OnKatanaVFXRequested;

    public void RaiseLandingEvent(Vector3 position)
    {
        OnLandingVFXRequested?.Invoke(position);
    }

    public void RaiseSlidingEvent(Vector3 position)
    {
        OnSlidingVFXRequested?.Invoke(position);
    }

    public void RaiseRunningEvent(Vector3 position, bool direction)
    {
        OnRunningVFXRequested?.Invoke(position, direction);
    }

    public void RaiseKatanaEvent(Vector3 position, bool direction)
    {
        OnKatanaVFXRequested?.Invoke(position, direction);
    }
}
