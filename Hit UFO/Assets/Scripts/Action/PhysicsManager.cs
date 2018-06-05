using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PhysicsManager : SSActionManager, ISSActionCallback, IActionManager
{
    public FirstSceneControl sceneController;
    public List<Emit> Fly;
    public int DiskNumber { get; set; }

    /** 
     * used是用来保存正在使用的动作 
     * free是用来保存还未被激活的动作 
     */

    private List<SSAction> used = new List<SSAction>();
    private List<SSAction> free = new List<SSAction>();

    /** 
     * GetSSAction这个函数是用来获取CCFlyAction这个动作的， 
     * 每次首次判断free那里还有没有未使用的CCFlyActon这个动作， 
     * 有就从free那里获取，没有就生成一个CCFlyAction 
     */

    SSAction GetSSAction()
    {
        SSAction action = null;
        if (free.Count > 0)
        {
            action = free[0];
            free.Remove(free[0]);
        }
        else
        {
            action = Instantiate(Fly[0]);
        }

        used.Add(action);
        return action;
    }

    public void FreeSSAction(SSAction action)
    {
        SSAction tmp = null;
        foreach (SSAction i in used)
        {
            if (action.GetInstanceID() == i.GetInstanceID())
            {
                tmp = i;
            }
        }
        if (tmp != null)
        {
            tmp.reset();
            free.Add(tmp);
            used.Remove(tmp);
        }
    }

    protected new void Start()
    {
        sceneController = (FirstSceneControl)Director.getInstance().currentSceneControl;
        sceneController.actionManager = this;
        Fly.Add(Emit.GetSSAction());

    }

    protected new void Update()
    {
        base.Update();
    }

    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0,
        string strParam = null,
        UnityEngine.Object objectParam = null)
    {
        if (source is Emit)
        {
            DiskNumber--;
            DiskFactory df = Singleton<DiskFactory>.Instance;
            df.FreeDisk(source.gameobject);
            FreeSSAction(source);
        }
    }

    public void StartThrow(Queue<GameObject> diskQueue)
    {
        foreach (GameObject tmp in diskQueue)
        {
            SSAction emit = GetSSAction();
            RunAction(tmp, emit, this);
            tmp.GetComponent<DiskData>().action = emit;
        }
    }
}
