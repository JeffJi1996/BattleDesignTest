using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int health;
    [SerializeField]private int currentHealth;
    public bool canBeHurt = true;
    private Animator anim;

    void Start()
    {
        currentHealth = health;
        anim = GetComponent<Animator>();
    }

    public void GetHurt(int damage)
    {
        if (canBeHurt)
        {
            ComboAttack.Instance.ResetAll();
            anim.SetTrigger("Hurt");
            currentHealth -= damage;
        }

        if (!canBeHurt)
        {
            Debug.Log("success");
            PlayerAbility.Instance.ChangeIntoSoul();
        }
    }

    public void CanBeHurt()
    {
        canBeHurt = true;
    }

    public void CanNotBeHurt()
    {
        canBeHurt = false;
    }

}
