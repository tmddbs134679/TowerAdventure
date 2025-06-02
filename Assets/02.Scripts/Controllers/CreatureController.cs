using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureController : BaseController
{
   // public virtual SkillBook Skills { get; set; }

    void Awake()
    {
        Init();
    }
    public override bool Init()
    {
        base.Init();

       // Skills = gameObject.GetOrAddComponent<skillbo>();

        return true;
    }


}
