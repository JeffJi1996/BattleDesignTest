using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Management : Singleton<UI_Management>
{
    [SerializeField]private Image healthbar;
    [SerializeField]private Image skillBar;

    [SerializeField] private Image AI_HealthBar;
    [SerializeField] private Image AI_PoiseBar;
    [SerializeField] private EnemyAI enemyAI;

    [SerializeField] private GameObject PlayerBar;
    [SerializeField] private GameObject AIBar;

    void Update()
    {
        healthbar.fillAmount = PlayerHealth.Instance.ReturnCurrentHealthBar();
        skillBar.fillAmount = PlayerAbility.Instance.ReturnCurrentSkillBar();
        AI_HealthBar.fillAmount = (float) enemyAI.currentHealth / enemyAI.health;
        AI_PoiseBar.fillAmount = (float) enemyAI.currentPoise / enemyAI.poise;
    }

    public void ShakeUI()
    {
        PlayerBar.GetComponent<Animator>().SetTrigger("Shake");
        AIBar.GetComponent<Animator>().SetTrigger("Shake");
    }


}
