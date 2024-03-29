using System.Collections;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public VFXChannelSO vfxChannel;
    public PlayerController playerController;

    private readonly int _floorLayer = 3;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        PlayerController.OnSlideTriggered += OnSlideTriggered;
        StartCoroutine(RaiseSlidingEvent());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _floorLayer)
        {
            Vector2 collisionCenter = GetCollisionCenter(collision);
            vfxChannel.RaiseLandingEvent(collisionCenter);
        }
    }

    void OnSlideTriggered()
    {
        vfxChannel.RaiseSlidingEvent(gameObject.transform.position);
    }

    private Vector3 GetCollisionCenter(Collision2D collision)
    {
        Vector2 center = Vector2.zero;
        foreach (ContactPoint2D contact in collision.contacts)
        {
            center += contact.point;
        }
        return center / collision.contacts.Length;
    }

    private IEnumerator RaiseSlidingEvent()
    {
        while (true)
        {
            if (playerController._Sliding)
            {
                vfxChannel.RaiseSlidingEvent(gameObject.transform.position);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
