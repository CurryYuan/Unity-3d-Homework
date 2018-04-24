﻿/**
 * 所有动作的基类
 */   
  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class SSAction : ScriptableObject
{

    public bool enable = false;
    public bool destroy = false;

    public GameObject gameobject { get; set; }
    public Transform transform { get; set; }
    public ISSActionCallback callback { get; set; }

    protected SSAction() { }

    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame  
    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }

    public virtual void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void reset()
    {
        enable = false;
        destroy = false;
        gameobject = null;
        transform = null;
        callback = null;
    }
}