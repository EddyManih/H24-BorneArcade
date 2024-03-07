using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VFX Channel")]
public class VFXChannelSO : ScriptableObject
{
    public UnityAction<ParticleSystem[], Vector3> OnCollisionVFXRequested;

    public void RaiseCollisionEvent(ParticleSystem[] particleSystems,
                                    Vector3 position)
    {
        if (OnCollisionVFXRequested != null)
        {
            OnCollisionVFXRequested.Invoke(particleSystems, position);
        }
    }
}
