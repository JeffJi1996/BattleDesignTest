using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemy : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float dizzTime;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartDizz()
    {
        StartCoroutine(dizzzz());
    }

    IEnumerator dizzzz()
    {
        anim.SetTrigger("dizz");
        yield return new WaitForSeconds(dizzTime);
        anim.SetTrigger("Idle");
    }
}
