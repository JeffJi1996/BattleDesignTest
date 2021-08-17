using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbility : Singleton<PlayerAbility>
{
    public float fullSoulValue;

    [SerializeField] private float currentSoulValue;
    [SerializeField] private float soulTime;

    public Animator anim;
    private bool isSouling = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeIntoSoul()
    {
        if (!isSouling)
        {
            SoulStart();
            StartCoroutine(SoulStateCountDown());
        }
    }

    public void SoulStart()
    {
        isSouling = true;
        anim.SetFloat("AnimSpeed", 1.5f);
    }

    public IEnumerator SoulStateCountDown()
    {
        yield return new WaitForSeconds(soulTime);
        SoulEnd();
    }

    public void SoulEnd()
    {
        isSouling = false;
        currentSoulValue = 0;
        anim.SetFloat("AnimSpeed", 1f);
    }

    public void ChangeAttackAnimSpeed(float speed)
    {
        anim.SetFloat("AnimSpeed",speed);
    }

    public void AddSoulValue(int soulValue)
    {
        if (currentSoulValue<fullSoulValue)
        {
            currentSoulValue += soulValue;
        }
    }

    public bool SoulState()
    {
        return isSouling;
    }
}
