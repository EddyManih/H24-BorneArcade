using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int playerIndex;

    public Animator animator;
    public Collider2D[] attackHitboxes;
    public Collider2D[] hurtboxes;

    public Transform firePoint;

    public float punchDamage;
    public float katanaDamage;
    public float gunDamage;

    private bool _canAttack = true;
    
    public delegate void KatanaTriggered();
    // public event KatanaTriggered OnKatanaTriggered;
    public delegate void GunTriggered();
    // public event GunTriggered OnGunTriggered;
    
    
    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        setActiveHurtbox(0);
    }

    public void PunchAttack()
    {
        if (!_canAttack)
            return;
        
        animator.SetTrigger("PunchAttack");
        _canAttack = false;
        setActiveHurtbox(1);
    }

    public void KatanaAttack()
    {
        if (!_canAttack)
            return;
        
        animator.SetTrigger("KatanaAttack");
        _canAttack = false;
    }
    
    public void GunAttack()
    {
        if (!_canAttack)
            return;
        
        animator.SetTrigger("GunAttack");
        _canAttack = false;
    }

    private void LaunchAttack(int attackIndex)
    {
        Collider2D col = attackHitboxes[attackIndex];

        var cols = Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.size, 0, LayerMask.GetMask("Hitboxes"));

        foreach (Collider2D c in cols)
        {
            if (c.transform.parent.parent == transform)
                continue;

            float damage = col.name switch
            {
                "PunchHitbox" => punchDamage,
                "KatanaHitbox" => katanaDamage,
                _ => 0
            };

            Debug.Log(col.name + " hit " + c.name + " of " + c.transform.parent.parent.name);
            c.transform.parent.parent.GetComponent<PlayerController>().healthManagerSO.DamageTaken((int) damage, gameObject);
            c.transform.parent.parent.GetComponent<KnockBackFeedback>().PlayFeedback(gameObject, attackIndex);
            if (col.name == "KatanaHitbox") c.transform.parent.parent.GetComponent<VFXController>().OnKatanaTriggered();
            // To implement with gun bullets
            // if (col.name == "GunHitbox") c.transform.parent.parent.GetComponent<VFXController>().OnGunTriggered();
        }
    }

    private void EndAttack()
    {
        _canAttack = true;
        setActiveHurtbox(0);
        GetComponentInParent(typeof(PlayerController)).GetComponent<PlayerController>().EnableMovement();
    }

    private void setActiveHurtbox(int hurtboxIndex)
    {
        foreach (var hurtbox in hurtboxes)
        {
            hurtbox.enabled = false;
        }

        hurtboxes[hurtboxIndex].enabled = true;
    }
    
    
}
