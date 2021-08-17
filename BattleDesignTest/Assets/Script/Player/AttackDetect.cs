using Unity.VisualScripting;
using UnityEngine;

public class AttackDetect : Singleton<AttackDetect>
{
    private bool LeftHandDetectStart;
    private bool RightHandDetectStart;
    private bool LeftFootDetectStart;
    private bool RightFootDetectStart;

    private bool hasHurt;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Transform LHandPos;
    [SerializeField] private Transform RHandPos;
    [SerializeField] private Transform LFootPos;
    [SerializeField] private Transform RFootPos;

    [SerializeField] private float LHandRange;
    [SerializeField] private float RHandRange;
    [SerializeField] private float LFootRange;
    [SerializeField] private float RFootRange;

    public PlayerAttackType[] PlayerAttackTypes;


    private void Detect(Transform atkPos, float atkRange, PlayerAttackType playerAttackType)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(atkPos.position, atkRange, enemyLayer);
        if (hitEnemies.Length>0 && !hasHurt)
        {
            foreach (var hitEnemy in hitEnemies)
            {
                int damage = Random.Range(playerAttackType.healthDamageMin, playerAttackType.healthDamageMax);
                int poise = Random.Range(playerAttackType.poiseDamageMin, playerAttackType.poiseDamageMax);
                hitEnemy.GetComponent<EnemyAI>().GetHurt(damage,poise);

                if (hitEnemy.GetComponent<EnemyAI>().currentPoise <= 0)
                {
                    hitEnemy.GetComponent<EnemyAI>().HurtInRecover();
                }

                if (PlayerAbility.Instance.SoulState())
                {
                    PlayerAbility.Instance.AddSoulValue(playerAttackType.soulPlus);
                }
            }
            hasHurt = true;
        }
    }

    private void Update()
    {
        if (LeftHandDetectStart)
        {
            Detect(LHandPos,LHandRange,PlayerAttackTypes[0]);
        }
        else if (RightHandDetectStart)
        {
            Detect(RHandPos, RHandRange,PlayerAttackTypes[1]);
        }
        else if (LeftFootDetectStart)
        {
            Detect(LFootPos,LFootRange,PlayerAttackTypes[0]);   
        }
        else if(RightFootDetectStart)
        {
            Detect(RFootPos,RFootRange,PlayerAttackTypes[1]);
        }
    }

    public void LHS()
    {
        LeftHandDetectStart = true;
    }

    public void LHE()
    {
        LeftHandDetectStart = false;
    }

    public void RHS()
    {
        RightHandDetectStart = true;
    }

    public void RHE()
    {
        RightHandDetectStart = false;
    }

    public void LFS()
    {
        LeftFootDetectStart = true;
    }
    public void LFE()
    {
        LeftFootDetectStart = false;
    }

    public void RFS()
    {
        RightFootDetectStart = true;
    }
    public void RFE()
    {
        RightFootDetectStart = false;
    }

    public void ClearHasHurt()
    {
        hasHurt = false;
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(LHandPos.position,LHandRange);
    //    Gizmos.DrawSphere(LFootPos.position, LFootRange);
    //    Gizmos.DrawSphere(RHandPos.position, RHandRange);
    //    Gizmos.DrawSphere(RFootPos.position, RFootRange);
    //}

    public void ClearDetect()
    {
        LeftHandDetectStart = false;
        RightHandDetectStart = false;
        LeftFootDetectStart = false;
        RightFootDetectStart = false;
    }
    

}
