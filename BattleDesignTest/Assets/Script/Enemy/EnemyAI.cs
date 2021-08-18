
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
    [SerializeField] private LayerMask playerLayerMask;
    public bool startDetect = false;
    private bool hasHurt = false;
    [SerializeField] private int damage;

    public Transform point1;
    public Transform point2;
    public float radius;


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

    public void SetState(State newState)
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
                anim.SetBool("Idle", true);
                anim.SetBool("Move", false);
            }

            if (currentWaitTime > waitTime)
            {
                StopCoroutine(m_previousAction);
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
                anim.SetBool("Idle", false);
                anim.SetBool("Move", true);
                agent.SetDestination(Player.transform.position);
            }
            else if (distance < idleRangeMin)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Move", true);
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

    private IEnumerator OnHitRecover()
    {
        anim.SetBool("HitRecover", true);
        agent.isStopped = true;
        //agent.enabled = false;

        yield return new WaitForSeconds(hitRecoverTime);
        anim.SetBool("HitRecover", false);
        currentPoise = poise;
        agent.isStopped = false;
        //agent.enabled = true;
        SetState(State.Chase);
        doOnce = false;
    }

    private void Update()
    {
        currentWaitTime += Time.deltaTime;
        transform.forward = Player.transform.position - transform.position;

        if (currentPoise <= 0 && !doOnce)
        {
            doOnce = true;
            SetState(State.HitRecover);
        }

        if (startDetect)
        {
            DetectPlayer(point1, point2, radius);
        }
    }

    public void HurtInRecover()
    {
        anim.SetTrigger("HurtHit");
        var direction = -(Player.transform.position - transform.position).normalized;
        agent.velocity = direction * 5;
        Debug.Log("Enemy Hurt");
    }

    public void DetectPlayer(Transform Point1, Transform Point2, float radius)
    {
        Collider[] player = Physics.OverlapCapsule(Point1.position, Point2.position, radius, playerLayerMask);
        if (player.Length > 0 && !hasHurt)
        {
            foreach (var playerCol in player)
            {
                PlayerHealth.Instance.GetHurt(damage);
                hasHurt = true;
            }

        }

    }
    
    public void StartDetect()
    {
        startDetect = true;
        hasHurt = false;
    }

    public void CloseDetect()
    {
        startDetect = false;
        hasHurt = true;
    }

    public void CloseCor()
    {
        StopAllCoroutines();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(point1.position, radius);
        Gizmos.DrawSphere(point2.position, radius);
    }




}
