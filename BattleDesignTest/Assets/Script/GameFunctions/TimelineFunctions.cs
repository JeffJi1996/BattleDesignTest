
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class TimelineFunctions : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public Transform enemyStartTrans;
    public Transform enemyEndTrans;
    public CinemachineFreeLook camera3Cam;
    private RuntimeAnimatorController player_AC;
    private RuntimeAnimatorController enemy_AC;
    public PlayableDirector playableDirector;
    public GameObject groundVFX;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playableDirector.Play();
        }
    }

    
    public void TimeLineStart()
    {
        ClosePlayerInput();
        ComboAttack.Instance.ResetAll();
        StopSoulState();
        SetTimelinePosition();

        player_AC = Player.GetComponent<Animator>().runtimeAnimatorController;
        Player.GetComponent<Animator>().runtimeAnimatorController = null;
        StopEnemy();
        enemy_AC = Enemy.GetComponent<Animator>().runtimeAnimatorController;
        Enemy.GetComponent<Animator>().runtimeAnimatorController = null;

        PlayerAbility.Instance.OpenVFX();
    }

    public void TimeLineEnd()
    {
        playableDirector.Evaluate();
        OpenPlayerInput();
        ClearSoul();

        Player.GetComponent<Animator>().runtimeAnimatorController = player_AC;
        Enemy.GetComponent<Animator>().runtimeAnimatorController = enemy_AC;
        ResetEnemy();

        PlayerAbility.Instance.CloseVFX();
    }

    public void HitEnemy()
    {
        CameraShake.Instance.ShakeCamera(5f,0.2f);
    }
    private void ClosePlayerInput()
    {
        //Close Mouse
        camera3Cam.m_YAxis.m_InputAxisName = null;
        camera3Cam.m_XAxis.m_InputAxisName = null;
        //Close CC
        Player.GetComponent<CharacterController>().enabled = false;
        //Close Input
        ComboAttack.Instance.CannotMove();
        ComboAttack.Instance.enabled = false;
    }

    private void OpenPlayerInput()
    {
        camera3Cam.m_YAxis.m_InputAxisName = "Mouse Y";
        camera3Cam.m_XAxis.m_InputAxisName = "Mouse X";

        Player.GetComponent<CharacterController>().enabled = true;
        ComboAttack.Instance.enabled = true;
        ComboAttack.Instance.CanMove();
    }

    private void StopSoulState()
    {
        if (PlayerAbility.Instance.SoulState())
        {
            StartCoroutine(PlayerAbility.Instance.SoulStateCountDown());
        }
    }

    private void ClearSoul()
    {
        PlayerAbility.Instance.SoulEnd();
    }

    private void SetTimelinePosition()
    {
        transform.position = Player.transform.position;
        transform.eulerAngles = Player.transform.eulerAngles;
    }

    private void StopEnemy()
    {
        Enemy.GetComponent<EnemyAI>().CloseCor();
        Enemy.GetComponent<NavMeshAgent>().speed = 0;
        Enemy.GetComponent<EnemyAI>().CloseDetect();
        Enemy.transform.position = enemyStartTrans.position;
        Enemy.transform.eulerAngles = enemyStartTrans.eulerAngles;
    }

    private void ResetEnemy()
    {
        Enemy.transform.GetChild(0).localPosition = Vector3.zero;
        Enemy.transform.GetChild(0).localEulerAngles = Vector3.zero;
        Enemy.GetComponent<EnemyAI>().SetState(EnemyAI.State.HitRecover);
        Enemy.GetComponent<Animator>().SetTrigger("HurtHit");
    }

    public void GroundVFX()
    {
        Instantiate(groundVFX, enemyEndTrans.position, Quaternion.identity);
    }

}
