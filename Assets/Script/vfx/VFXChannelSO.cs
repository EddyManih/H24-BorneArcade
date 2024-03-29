using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject
{
  public UnityAction<Vector3> OnLandingVFXRequested;
  public UnityAction<Vector3> OnSlidingVFXRequested;
  public UnityAction<Vector3> OnIsSlidingVFXRequested;

  public void RaiseLandingEvent(Vector3 position)
  {
    if (OnLandingVFXRequested != null)
    {
      OnLandingVFXRequested.Invoke(position);
    }
  }

  public void RaiseSlidingEvent(Vector3 position)
  {
    if (OnSlidingVFXRequested != null)
    {
      OnSlidingVFXRequested.Invoke(position);
    }
  }

  public void RaiseIsSlidingEvent(Vector3 position)
  {
    if (OnIsSlidingVFXRequested != null)
    {
      OnIsSlidingVFXRequested.Invoke(position);
    }
  }
}
