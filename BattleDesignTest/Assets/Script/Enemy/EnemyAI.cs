
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : EnemyBase
{
    public float idleRangeMax;
    public float idleRangeMin;

    private float currentWaitTime;

    [SerializeField] private float attackTime;
    [SerializeField] private float hitRecoverTime;


    private IEnumerator m_previousAction = null;
    private bool m_resume = false;
    private bool doOnce = false;

    public enum State
    {
        Idle,
        Chase,
        Attack,
        HitRecover,
    }

    protected override void Start()
    {
        base.Start();
        SetState(State.Chase);
        agent.updateRotation = false;
    }

    public State currentState;

    private void SetState(State newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case State.Idle:
                m_previousAction = OnIdle();
                StartCoroutine(OnIdle());
                break;
            case State.Chase:
                m_previousAction = OnChase();
                StartCoroutine(OnChase());
                break;
            case State.Attack:
                m_previousAction = OnAttack();
                StartCoroutine(OnAttack());
                break;
            case State.HitRecover:
                m_previousAction = OnHitRecover();
                StartCoroutine(OnHitRecover());
                break;
        }
    }

    private IEnumerator OnHitRecover()
    {
        agent.isStopped = true;
        //agent.enabled = false;

        yield return new WaitForSeconds(hitRecoverTime);
        currentPoise = poise;
        //agent.enabled = true;
        SetState(State.Chase);
        doOnce = false;
    }

    private IEnumerator OnIdle()
    {
        float waitTime = Random.Range(2f, 4f);
        currentWaitTime = 0f;
        while (currentState == State.Idle)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > idleRangeMax ||
                Vector3.Distance(transform.position, Player.transform.position) < idleRangeMin)
            {
                SetState(State.Chase);
            }
            else
            {
                agent.velocity = Vector3.zero;
            }

            if (currentWaitTime > waitTime)
            {
                SetState(State.Attack);
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator OnChase()
    {
        while (currentState == State.Chase)
        {
            var distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance > idleRangeMax)
            {
                agent.SetDestination(Player.transform.position);
            }
            else if (distance < idleRangeMin)
            {
                var movDistance = idleRangeMin - distance;
                var movDirector = (Player.transform.position - transform.position).normalized;
                agent.SetDestination(transform.position - movDirector * movDistance);
            }
            else
            {
                SetState(State.Idle);
            }
            yield return new WaitForFixedUpdate();
        }
    }
    private IEnumerator OnAttack()
    {
        Attack();
        yield return new WaitForSeconds(attackTime);
        SetState(State.Idle);
    }



    private void Update()
    {
        currentWaitTime += Time.deltaTime;
        transform.forward = Player.transform.position - transform.position;

        if (currentPoise <= 0 &&!doOnce)
        {
            doOnce = true;
            SetState(State.HitRecover);
        }
    }

    public void HurtInRecover()
    {
        var direction = -(Player.transform.position - transform.position).normalized;
        agent.velocity = direction*5;
        Debug.Log("Enemy Hurt");
    }


    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, idleRangeMax);
    //    Gizmos.DrawSphere(transform.position, idleRangeMin);
    //}
}
