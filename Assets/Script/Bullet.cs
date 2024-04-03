using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    private const int FLOOR_LAYER = 3;
    private const int HITBOX_LAYER = 6;
    
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 4f;
    public GameObject trailingEmptyObject;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.transform.GameObject().layer == HITBOX_LAYER)
        {
            GameObject player = hitInfo.transform.parent.parent.gameObject;
            player.GetComponent<PlayerController>().healthManagerSO.DamageTaken((int) damage); 
            player.GetComponent<KnockBackFeedback>().PlayFeedback(trailingEmptyObject, 2);
            Destroy(gameObject);
        }

        if (hitInfo.transform.GameObject().layer == FLOOR_LAYER)
        {
            Destroy(gameObject);
        }
    }
}
