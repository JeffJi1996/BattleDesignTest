
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAbility : Singleton<PlayerAbility>
{
    public float fullSoulValue;

    [SerializeField] private float currentSoulValue;
    [SerializeField] private float soulTime;

    [SerializeField] private GameObject soulPartical1;
    [SerializeField] private GameObject handEffect1;
    [SerializeField] private GameObject handEffect2;

    [SerializeField] private Animator camAnimator;

    [SerializeField] private int SkillDamage;

    public Animator anim;
    private bool isSouling = false;
    private bool canUseSkill = true;
    private bool doOnce = true;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private GameObject UI_canUseSkill;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (currentSoulValue >= fullSoulValue && canUseSkill)
        {
            UI_canUseSkill.SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                canUseSkill = false;
                playableDirector.Play();
            }
        }
        else
        {
            UI_canUseSkill.SetActive(false);
        }
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

    public float ReturnCurrentSkillBar()
    {
        return currentSoulValue / fullSoulValue;
    }

    public int ReturnSkillDamage()
    {
        return SkillDamage;
    }

    public void CanUseSkill()
    {
        canUseSkill = true;
    }
}
