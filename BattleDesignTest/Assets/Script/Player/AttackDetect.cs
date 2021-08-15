using Unity.VisualScripting;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    private bool LeftHandDetectStart;
    private bool RightHandDetectStart;
    private bool LeftFootDetectStart;
    private bool RightFootDetectStart;

    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Transform LHandPos;
    [SerializeField] private Transform RHandPos;
    [SerializeField] private Transform LFootPos;
    [SerializeField] private Transform RFootPos;

    [SerializeField] private float LHandRange;
    [SerializeField] private float RHandRange;
    [SerializeField] private float LFootRange;
    [SerializeField] private float RFootRange;


    private void Detect(Transform atkPos, float atkRange)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(atkPos.position, atkRange, enemyLayer);
        if (hitEnemies.Length>0)
        {
            foreach (var hitEnemy in hitEnemies)
            {
                Debug.Log(hitEnemy.name);
            }
        }
    }

    private void Update()
    {
        if (LeftHandDetectStart)
        {
            Detect(LHandPos,LHandRange);
        }
        else if (RightHandDetectStart)
        {
            Detect(RHandPos, RHandRange);
        }
        else if (LeftFootDetectStart)
        {
            Detect(LFootPos,LFootRange);   
        }
        else if(RightFootDetectStart)
        {
            Detect(RFootPos,RFootRange);
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

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(LHandPos.position,LHandRange);
    //    Gizmos.DrawSphere(LFootPos.position, LFootRange);
    //    Gizmos.DrawSphere(RHandPos.position, RHandRange);
    //    Gizmos.DrawSphere(RFootPos.position, RFootRange);
    //}

}
