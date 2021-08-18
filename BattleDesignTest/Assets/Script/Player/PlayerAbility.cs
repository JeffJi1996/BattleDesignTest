using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbility : Singleton<PlayerAbility>
{
    public float fullSoulValue;

    [SerializeField] private float currentSoulValue;
    [SerializeField] private float soulTime;

    [SerializeField] private GameObject soulPartical1;
    [SerializeField] private GameObject handEffect1;
    [SerializeField] private GameObject handEffect2;

    [SerializeField] private Animator camAnimator;

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
        StartCoroutine(TimePause());
        camAnimator.SetTrigger("ToSoul");
        OpenVFX();
    }

    public IEnumerator SoulStateCountDown()
    {
        yield return new WaitForSeconds(soulTime);
        SoulEnd();
        CloseVFX();
    }

    public void SoulEnd()
    {
        isSouling = false;
        currentSoulValue = 0;
        camAnimator.SetTrigger("ToIdle");
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

    public void OpenVFX()
    {
        soulPartical1.SetActive(true);
        handEffect1.SetActive(true);
        handEffect2.SetActive(true);
    }

    public void CloseVFX()
    {
        soulPartical1.SetActive(false);
        handEffect1.SetActive(false);
        handEffect2.SetActive(false);
    }

    IEnumerator TimePause()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }
}
