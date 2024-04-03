using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public SFXChannelSO sfxChannel;
    public AudioClip[] punchSFX;
    public AudioClip[] punchHitSFX;
    public AudioClip[] katanaSFX;
    public AudioClip[] katanaHitSFX;
    public AudioClip[] gunSFX;
    public AudioClip[] gunHitSFX;
    public float volumeScale = 1f;

    private void Awake()
    {
        if (sfxChannel != null)
        {
            sfxChannel.OnPunchSFXRequested += PlayPunchSFX;
            sfxChannel.OnPunchHitSFXRequested += PlayPunchHitSFX;
            sfxChannel.OnKatanaSFXRequested += PlayKatanaSFX;
            sfxChannel.OnKatanaHitSFXRequested += PlayKatanaHitSFX;
            sfxChannel.OnGunSFXRequested += PlayGunSFX;
            sfxChannel.OnGunHitSFXRequested += PlayGunHitSFX;
        }
    }

    private void OnDestroy()
    {
        if (sfxChannel != null)
        {
            sfxChannel.OnPunchSFXRequested -= PlayPunchSFX;
            sfxChannel.OnPunchHitSFXRequested -= PlayPunchHitSFX;
            sfxChannel.OnKatanaSFXRequested -= PlayKatanaSFX;
            sfxChannel.OnKatanaHitSFXRequested -= PlayKatanaHitSFX;
            sfxChannel.OnGunSFXRequested -= PlayGunSFX;
            sfxChannel.OnGunHitSFXRequested -= PlayGunHitSFX;
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

    private void PlayPunchHitSFX()
    {
        foreach (AudioClip clip in punchHitSFX)
        {
            GameObject sfxObject = new("sfxObject");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volumeScale;
            audioSource.Play();
            Destroy(sfxObject, clip.length);
        }
    }

    private void PlayKatanaSFX()
    {
        foreach (AudioClip clip in katanaSFX)
        {
            GameObject sfxObject = new("sfxObject");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volumeScale;
            audioSource.Play();
            Destroy(sfxObject, clip.length);
        }
    }

    private void PlayKatanaHitSFX()
    {
        foreach (AudioClip clip in katanaHitSFX)
        {
            GameObject sfxObject = new("sfxObject");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volumeScale;
            audioSource.Play();
            Destroy(sfxObject, clip.length);
        }
    }

    private void PlayGunSFX()
    {
        foreach (AudioClip clip in gunSFX)
        {
            GameObject sfxObject = new("sfxObject");
            AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volumeScale;
            audioSource.Play();
            Destroy(sfxObject, clip.length);
        }
    }

    private void PlayGunHitSFX()
    {
        foreach (AudioClip clip in gunHitSFX)
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
