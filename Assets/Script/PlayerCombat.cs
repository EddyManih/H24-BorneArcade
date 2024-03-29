using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Collider2D[] attackHitboxes;
    public Collider2D[] hurtboxes;

    public float punchDamage;
    public float katanaDamage;

    [SerializeField]
    public UnityEvent onPunchHit, onKatanaHit;

    private bool _canAttack = true;
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PunchAttack();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            KatanaAttack();
        }
    }

    private void Awake()
    {
        setActiveHurtbox(0);
    }

    void PunchAttack()
    {
        if (!_canAttack)
            return;
        
        animator.SetTrigger("PunchAttack");
        _canAttack = false;
        setActiveHurtbox(1);
    }

    void KatanaAttack()
    {
        if (!_canAttack)
            return;
        
        animator.SetTrigger("KatanaAttack");
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

            float damage = 0;
            switch (c.name)
            {
                case "PunchHitbox":
                    damage = punchDamage;
                    break;
                case "KatanaHitbox":
                    damage = katanaDamage;
                    break;
            }

            Debug.Log(col.name + " hit " + c.name + " of " + c.transform.parent.parent.name);
            c.transform.parent.parent.GetComponent<PlayerAttack>().onKatanaHit?.Invoke();
        }
    }

    private void EndAttack()
    {
        _canAttack = true;
        setActiveHurtbox(0);
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