using System;
using UnityEngine;

namespace GameItem
{
    [Serializable]
    public struct BattleStatData
    {
        [SerializeField, Range(0, 10000)] public int health;
        [SerializeField, Range(0, 10000)] public int mana;
        [SerializeField, Range(0, 1000)] public int attack;
        [SerializeField, Range(0, 1000)] public int defence;
        [SerializeField, Range(0, 1000)] public int accuracy;
        [SerializeField, Range(0, 1000)] public int evasion;

        public BattleStatData(int health, int mana, int attack, int defence, int accuracy, int evasion)
        {
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defence = defence;
            this.accuracy = accuracy;
            this.evasion = evasion;
        }

        public override bool Equals(object obj)
        {
            return obj is BattleStatData data &&
                   health == data.health &&
                   mana == data.mana &&
                   attack == data.attack &&
                   defence == data.defence &&
                   accuracy == data.accuracy &&
                   evasion == data.evasion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(health, mana, attack, defence, accuracy, evasion);
        }

        //public override int GetHashCode()
        //{
        //    int hash = health * 11 + 9176;
        //    hash = hash * 13 + mana;
        //    hash = hash * 17 + attack;
        //    hash = hash * 19 + defence;
        //    hash = hash * 23 + accuracy;
        //    hash = hash * 29 + evasion;
        //    return hash * 31;
        //}

        public static BattleStatData operator +(BattleStatData left, BattleStatData right)
        {
            BattleStatData result = new BattleStatData
            (
                left.health + right.health,
                left.mana + right.mana,
                left.attack + right.attack,
                left.defence + right.defence,
                left.accuracy + right.accuracy,
                left.evasion + right.evasion
            );
            return result;
        }

        public static BattleStatData operator -(BattleStatData left, BattleStatData right)
        {
            BattleStatData result = new BattleStatData
            (
                left.health - right.health,
                left.mana - right.mana,
                left.attack - right.attack,
                left.defence - right.defence,
                left.accuracy - right.accuracy,
                left.evasion - right.evasion
            );
            return result;
        }

        public static BattleStatData operator *(BattleStatData left, BattleStatData right)
        {
            BattleStatData result = new BattleStatData
            (
                left.health * right.health,
                left.mana * right.mana,
                left.attack * right.attack,
                left.defence * right.defence,
                left.accuracy * right.accuracy,
                left.evasion * right.evasion
            );
            return result;
        }

        public static BattleStatData operator /(BattleStatData left, BattleStatData right)
        {
            BattleStatData result = new BattleStatData
            (
                left.health / right.health,
                left.mana / right.mana,
                left.attack / right.attack,
                left.defence / right.defence,
                left.accuracy / right.accuracy,
                left.evasion / right.evasion
            );
            return result;
        }

        public static bool operator ==(BattleStatData left, BattleStatData right)
        {
            if (left.health != right.health)
                return false;
            if (left.mana != right.mana)
                return false;
            if (left.attack != right.attack)
                return false;
            if (left.defence != right.defence)
                return false;
            if (left.accuracy != right.accuracy)
                return false;
            if (left.evasion != right.evasion)
                return false;
            return true;
        }

        public static bool operator !=(BattleStatData left, BattleStatData right)
        {
            if (left.health != right.health)
                return true;
            if (left.mana != right.mana)
                return true;
            if (left.attack != right.attack)
                return true;
            if (left.defence != right.defence)
                return true;
            if (left.accuracy != right.accuracy)
                return true;
            if (left.evasion != right.evasion)
                return true;
            return false;
        }
    }
}