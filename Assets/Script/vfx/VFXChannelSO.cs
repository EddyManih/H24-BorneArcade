using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject
{
    public UnityAction<Vector3> OnLandingVFXRequested;
    public UnityAction<Vector3> OnSlidingVFXRequested;

    public void RaiseLandingEvent(Vector3 position)
    {
        OnLandingVFXRequested?.Invoke(position);
    }

    public void RaiseSlidingEvent(Vector3 position)
    {
        OnSlidingVFXRequested?.Invoke(position);
    }
}
