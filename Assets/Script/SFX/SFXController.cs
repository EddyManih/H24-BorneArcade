using UnityEngine;

public class SFXController : MonoBehaviour
{
    public SFXChannelSO sfxChannel;

    public void OnPunchTriggered()
    {
        sfxChannel.RaisePunchSFXEvent();
    }

    public void OnPunchHitTriggered()
    {
        sfxChannel.RaisePunchHitSFXEvent();
    }
}
