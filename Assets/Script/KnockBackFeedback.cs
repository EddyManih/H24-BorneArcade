using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeedback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    
    [SerializeField]
    private float[] strength;
    private float delay = 0.15f;
    public float directionX, directionY;

    public UnityEvent OnBegin, OnDone;
    
    public Animator animator;
    public PlayerController playerController;

    public void PlayFeedback(GameObject sender, int attackIndex)
    {

        animator.SetTrigger("Hurt");
        playerController.EnableKnockbackState();
        // Debug.Log("PlayFeedback called on " + gameObject.name + " by " + sender.name + "!");
        
        StopAllCoroutines();
        OnBegin?.Invoke();
        
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        direction.y += 0.2f;

        rb2d.AddForce(direction*strength[attackIndex], ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }
    
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

}
