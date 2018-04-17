﻿/** 
 * 这个文件是实现飞碟的飞行动作 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{

    /** 
     * acceleration是重力加速度，为9.8 
     */

    float acceleration;

    /** 
     * horizontalSpeed是飞碟水平方向的速度 
     */

    float horizontalSpeed;

    /** 
     * direction是飞碟的初始飞行方向 
     */

    Vector3 direction;

    /** 
     * time是飞碟已经飞行的时间 
     */

    float time;

    public override void Start()
    {
        enable = true;
        acceleration = 9.8f;
        time = 0;
        horizontalSpeed = gameobject.GetComponent<DiskData>().speed;
        direction = gameobject.GetComponent<DiskData>().direction;
    }

    // Update is called once per frame  
    public override void Update()
    {
        if (gameobject.activeSelf)
        {
            /** 
             * 计算飞碟的累计飞行时间 
             */
            time += Time.deltaTime;

            /** 
             * 飞碟在竖直方向的运动 
             */

            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);

            /** 
             * 飞碟在水平方向的运动 
             */

            transform.Translate(direction * horizontalSpeed * Time.deltaTime);

            /** 
             * 当飞碟的y坐标比-4小时，飞碟落地 
             */

            if (this.transform.position.y < -4)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }

    }

    public static CCFlyAction GetSSAction()
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        return action;
    }
}