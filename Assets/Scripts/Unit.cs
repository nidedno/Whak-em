using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] bool isGood = false;
    Animator animator;

    private bool isDead = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Back(float speed = 1f)
    {
        if(gameObject == null) return;
    
            
        animator.SetTrigger("Back");

    }

    public void HitUnit()
    {
        if(health > 0 ){
            EffectsController.Instance.CreateEffect("hit",transform.position);
        }
        if(isGood == true && isDead == false){
            HealthBar.Instance.TakeDamage();
        }

        health -= 1;

        if(health <= 0){
            isDead = true;
            Die();
        }
    }
    private void Die(float speed = 1f)
    {
        if(gameObject == null) return;

        animator.SetTrigger("Back");

    }

    public void Spawn(float speed =1f )
    {
        animator.speed = speed;
        animator.SetTrigger("Spawn");
    }
    void OnMouseDown()
    {
        HitUnit();
    }
    public void FakeDestroy()
    {
        Destroy(gameObject);

    }
    public void DamageOnEscape()
    {
        if(isGood == false && isDead == false){
            HealthBar.Instance.TakeDamage();
        }
    }

}
