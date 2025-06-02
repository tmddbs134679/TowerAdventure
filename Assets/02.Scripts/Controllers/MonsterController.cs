using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : CreatureController
{
    public override bool Init()
    {
        base.Init();
        ObjectType = EOBJECTTPYE.MONSTER;
        
        //TODO


        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
