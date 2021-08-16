using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public int health;
    public int currentHealth;

    public int poise;
    public int currentPoise;

    public Rigidbody rb;
    public NavMeshAgent agent;
    public Animator anim;

    public GameObject Player;

    protected virtual void Start()
    {
        currentHealth = health;
        currentPoise = poise;
    }

    public virtual void GetHurt(int damage, int poiseDamage)
    {
        currentHealth -= damage;
        currentPoise -= poiseDamage;
    }

    protected virtual void Attack()
    {
        anim.SetTrigger("Attack");

    }

}
