using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class PlayerController : CreatureController
{
    [SerializeField]
    public GameObject Indicator;
    public override bool Init()
    {
        base.Init();

        ObjectType = EOBJECTTPYE.PLAYER;

        return true;
    }
}
