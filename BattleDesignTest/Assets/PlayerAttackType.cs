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
    public float healthDamageMin;
    public float healthDamageMax;
    public float poiseDamageMin;
    public float poiseDamageMax;
}
