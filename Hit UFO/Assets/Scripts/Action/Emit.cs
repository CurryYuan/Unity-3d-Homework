
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Emit : SSAction
{
    bool enableEmit;//使力作用一次，不想产生变加速运动  
    Vector3 force;//力  
    float startX;//起始位置  
    public FirstSceneControl sceneControler;//引入场记  
                                            // Use this for initialization  
    public override void Start()
    {
        enableEmit = true;
        enable = true;
        sceneControler = (FirstSceneControl)Director.getInstance().currentSceneControl;

        if (gameobject.GetComponent<Rigidbody>() == null)
        {
            gameobject.AddComponent<Rigidbody>();
        }
        //startX = 6 - Random.value * 12;
        //this.transform.position = new Vector3(startX, 0, 0);
        //根据轮数设置力的大小  
        force = new Vector3(6 * Random.Range(-1, 1), 6 * Random.Range(0.5f, 2), 13 + 2 * sceneControler.currentRound);
        //force = new Vector3(1, 100, 100);
    }
    public static Emit GetSSAction()
    {
        Emit action = CreateInstance<Emit>();
        return action;
    }

    public override void Update()
    {
        //  

    }
    public void Destory()//回调函数  
    {
        destroy = true;
        callback.SSActionEvent(this);
    }
    // Update is called once per frame  
    public override void FixedUpdate()
    {

        if (!this.destroy)
        {
            if (enableEmit&&gameobject.activeSelf)
            {
                gameobject.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                enableEmit = false;
            }
        }
    }

}

