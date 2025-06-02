using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{

    public EOBJECTTPYE ObjectType { get; protected set; }
    private void Awake()
    {
        Init();
    }

    void Start()
    {
        
    }


    bool _init = false;

    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
