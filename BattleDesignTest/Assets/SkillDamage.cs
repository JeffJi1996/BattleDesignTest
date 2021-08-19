using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<IdleEnemy>() != null)
        {
            col.GetComponent<IdleEnemy>().StartDizz();
        }

        if (col.GetComponent<EnemyAI>() != null)
        {
            col.GetComponent<EnemyAI>().ReduceHealth(PlayerAbility.Instance.ReturnSkillDamage());
        }
    }
}
