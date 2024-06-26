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
    
    public GameObject bulletPrefab;

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

        var playerController = GetComponentInParent<PlayerController>();
        
        if (playerController._Sliding)
        {
            playerController.StopSliding();
        }
        
        animator.SetTrigger("PunchAttack");
        _canAttack = false;
        setActiveHurtbox(1);
        gameObject.GetComponent<SFXController>().OnPunchTriggered();
    }

    public void KatanaAttack()
    {        
        if (!_canAttack)
            return;

        var playerController = GetComponentInParent<PlayerController>();

        if (playerController._Sliding)
        {
            playerController.StopSliding();
        }

        animator.SetTrigger("KatanaAttack");
        _canAttack = false;
        gameObject.GetComponent<SFXController>().OnKatanaTriggered();
    }
    
    public void GunAttack()
    {
        if (!_canAttack)
            return;
        
        var playerController = GetComponentInParent<PlayerController>();

        if (playerController._Sliding)
        {
            playerController.StopSliding();
        }
        
        animator.SetTrigger("GunAttack");
        _canAttack = false;
        gameObject.GetComponent<SFXController>().OnGunTriggered();
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

            // Debug.Log(col.name + " hit " + c.name + " of " + c.transform.parent.parent.name);
            c.transform.parent.parent.GetComponent<PlayerController>().healthManagerSO.DamageTaken((int)damage);
            c.transform.parent.parent.GetComponent<KnockBackFeedback>().PlayFeedback(gameObject, attackIndex);
            if (col.name == "PunchHitbox") c.transform.parent.parent.GetComponent<SFXController>().OnPunchHitTriggered();
            if (col.name == "KatanaHitbox")
            {
                c.transform.parent.parent.GetComponent<VFXController>().OnKatanaTriggered();
                c.transform.parent.parent.GetComponent<SFXController>().OnKatanaHitTriggered();
            }
            // To implement with gun bullets
            // if (col.name == "GunHitbox")
            // {
            //     c.transform.parent.parent.GetComponent<VFXController>().OnGunTriggered();
            //     c.transform.parent.parent.GetComponent<SFXController>().OnGunHitTriggered();
            // }
        }
    }
    
    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().damage = gunDamage;
    }
    
    private void EndAttack()
    {
        _canAttack = true;
        setActiveHurtbox(0);
        //GetComponentInParent(typeof(PlayerController)).GetComponent<PlayerController>().EnableMovement();
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
