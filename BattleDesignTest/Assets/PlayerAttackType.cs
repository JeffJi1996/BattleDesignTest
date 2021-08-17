using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttackType
{
    public enum AttackType
    {
        LightAttack,
        HeavyAttack,
    }
    public AttackType attackType;
    public int healthDamageMin;
    public int healthDamageMax;
    public int poiseDamageMin;
    public int poiseDamageMax;

    public int soulPlus;
}
