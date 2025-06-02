using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Define
{
    public enum EPLAYERSTATE
    {
        NONE,
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
        NONE,
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


    public enum EOBJECTTPYE
    {
        NONE,
        PLAYER,
        MONSTER,
        PROJECTILE,
    }

    public enum EUIEVENT
    {
        CLICK,
        PRESSED,
        POINTERDOWN,
        POINTERUP,
        BEGINDRAG,
        DRAG,
        ENDDRAG,
    }

    public enum ESKILLTYPE
    {

    }
}
