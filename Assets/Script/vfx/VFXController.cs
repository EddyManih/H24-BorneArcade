using System.Collections;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public VFXChannelSO vfxChannel;
    public PlayerController playerController;
    public PlayerAttack playerAttack;

    private readonly int _floorLayer = 3;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        PlayerController.OnSlideTriggered += OnSlideTriggered;
        PlayerAttack.OnKatanaTriggered += OnKatanaTriggered;
        StartCoroutine(RaiseSlidingEvent());
        StartCoroutine(RaiseRunningEvent());
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

    void OnKatanaTriggered()
    {
        float yOffset = 0.1f;
        Vector3 position = gameObject.transform.position;
        position.y = gameObject.GetComponent<Collider2D>().bounds.min.y + yOffset;
        vfxChannel.RaiseKatanaEvent(position, playerController._Flipped);
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

    private IEnumerator RaiseRunningEvent()
    {
        float yOffset = 0.1f;

        while (true)
        {
            Vector3 position = gameObject.transform.position;
            position.y = gameObject.GetComponent<BoxCollider2D>().bounds.min.y + yOffset;

            if (!playerController._Grounded)
            {
                yield return new WaitForSeconds(0.2f);
            }

            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                position.x = gameObject.GetComponent<BoxCollider2D>().bounds.min.x;
                vfxChannel.RaiseRunningEvent(position, false);
            }
            else if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                position.x = gameObject.GetComponent<BoxCollider2D>().bounds.max.x;
                vfxChannel.RaiseRunningEvent(position, true);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
