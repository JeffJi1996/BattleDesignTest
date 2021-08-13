using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    bool comboPossible;
    public int comboStep;
    bool inputHeavy;

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
                anim.Play("Player_LightAtk_B");
            }
            if (comboStep == 3)
            {
                anim.Play("Player_LightAtk_C");
            }
        }
        if (inputHeavy)
        {
            
            if (comboStep==2)
            {
                anim.Play("Player_HeavyAtk_B");
            }
            if (comboStep==3)
            {
                anim.Play("Player_HeavyAtk_C");
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
            anim.Play("Player_LightAtk_A");
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
}
