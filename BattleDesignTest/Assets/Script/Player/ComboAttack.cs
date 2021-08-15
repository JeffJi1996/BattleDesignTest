using UnityEngine;

public class ComboAttack : Singleton<ComboAttack>
{
    [SerializeField] private Animator anim;
    private bool canMove;
    bool comboPossible;
    public int comboStep;
    bool inputHeavy;

    void Start()
    {
        canMove = true;
    }
    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAtk()
    {
        if (!inputHeavy)
        {
            if (comboStep == 2)
            {
                anim.Play("Player_Light_Attack2");
            }
            if (comboStep == 3)
            {
                anim.Play("Player_Light_Attack3");
            }
        }
        if (inputHeavy)
        {
            if (comboStep==2)
            {
                anim.Play("Player_Heavy_Attack1");
            }
            if (comboStep==3)
            {
                anim.Play("Player_Heavy_Attack2");
            }
        }
    }

    public void ResetCombo()
    {
        comboPossible = false;
        inputHeavy = false;
        comboStep = 0;
    }

    void LightAtk()
    {
        if (comboStep == 0)
        {
            anim.Play("Player_Light_Attack1");
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    void HeavyAttack()
    {
        if (comboPossible)
        {
            comboPossible = false;
            inputHeavy = true;
        }
    }

    public void CannotMove()
    {
        canMove = false;
    }

    public void CanMove()
    {
        canMove = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LightAtk();
        }

        if (Input.GetMouseButtonDown(1))
        {
            HeavyAttack();
        }
    }

    public bool CanMoveState()
    {
        return canMove;
    }
}
