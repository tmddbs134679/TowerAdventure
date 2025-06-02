using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
public class PlayerController : CreatureController
{

    public override bool Init()
    {
        base.Init();

        ObjectType = EOBJECTTPYE.PLAYER;

        return true;
    }
}
