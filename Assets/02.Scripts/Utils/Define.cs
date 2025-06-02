using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Define
{
    public enum EPLAYERSTATE
    {
        FREELOOK,
        ATTACK,
        SKILL,
        DODGE,
        JUMP,
        CLIMB,
        STUN,
        DEAD
    }

    public enum EENEMYSTATE
    {
        IDLE,
        CHASING,
        ATTACK,
        SKILL,
        STUN,
        DEAD
    }

    public enum EMONSKILLTYPE
    {

    }

    public enum EFACTION
    {
        NONE,
        PLAYER,
        ENEMY,
        NEUTRAL
    }


}
