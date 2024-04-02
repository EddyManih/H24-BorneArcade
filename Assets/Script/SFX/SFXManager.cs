using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public SFXChannelSO sfxChannel;
    public AudioClip[] punchSFX;
    public float volumeScale = 1f;

    private void Awake()
    {
        if (sfxChannel != null)
        {
            sfxChannel.OnPunchSFXRequested += PlayPunchSFX;
        }
    }

    private void PlayPunchSFX()
    {
        foreach (AudioClip clip in punchSFX)
        {
            GameObject sfxObject = new("sfxObject");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volumeScale;
            audioSource.Play();
            Destroy(sfxObject, clip.length);
        }
    }
}
