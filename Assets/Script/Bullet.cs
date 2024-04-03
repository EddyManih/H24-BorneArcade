using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
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
        Debug.Log(LayerMask.GetMask("Hitboxes"));
        if (hitInfo.transform.GameObject().layer == 6)
        {
            GameObject player = hitInfo.transform.parent.parent.gameObject;
            player.GetComponent<PlayerController>().healthManagerSO.DamageTaken((int) damage); 
            player.GetComponent<KnockBackFeedback>().PlayFeedback(trailingEmptyObject, 2);
            Destroy(gameObject);
        }
    }
}
