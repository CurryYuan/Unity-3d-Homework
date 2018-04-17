/** 
 * 这个文件是用来控制主游戏场景的 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneControl : MonoBehaviour, ISceneControl, IUserAction
{

    /** 
     * actionManager是用来指定当前的动作管理器 
     */

    public CCActionManager actionManager { get; set; }

    /** 
     * scoreRecorder是用来指定当前的记分管理对象的 
     */

    public ScoreRecorder scoreRecorder { get; set; }

    /** 
     * diskQueue是用来保存一个回合要发射的飞碟 
     */

    public Queue<GameObject> diskQueue = new Queue<GameObject>();

    /** 
     * diskNumber是用来保存一回合要发射的飞碟总数 
     */

    private int diskNumber;

    /** 
     * currentRound是用来保存当前是那一回合 
     */

    private int currentRound = -1;

    /** 
     * round是用来保存总共有多少回合，这里是3， 
     * 不过，这个游戏的实现是不断的循环的，即过了 
     * 第三回合，又回到第一回合 
     */

    public int round = 3;

    /** 
     * time是用来保存每个飞碟的发射时间间隔 
     */

    private float time = 0;

    /** 
     * gameState是用来保存当前的游戏状态 
     */

    private GameState gameState = GameState.START;

    void Awake()
    {
        Director director = Director.getInstance();
        director.currentSceneControl = this;
        diskNumber = 10;
        this.gameObject.AddComponent<ScoreRecorder>();
        this.gameObject.AddComponent<DiskFactory>();
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
        director.currentSceneControl.LoadResources();
    }

    private void Update()
    {
        /** 
         * 以下代码用来管理游戏的状态 
         */

        if (actionManager.DiskNumber == 0 && gameState == GameState.RUNNING)
        {
            gameState = GameState.ROUND_FINISH;

        }

        if (actionManager.DiskNumber == 0 && gameState == GameState.ROUND_START)
        {
            currentRound = (currentRound + 1) % round;
            NextRound();
            actionManager.DiskNumber = 10;
            gameState = GameState.RUNNING;
        }

        if (time > 1)
        {
            ThrowDisk();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }


    }

    private void NextRound()
    {
        DiskFactory df = Singleton<DiskFactory>.Instance;
        for (int i = 0; i < diskNumber; i++)
        {
            diskQueue.Enqueue(df.GetDisk(currentRound));
        }

        actionManager.StartThrow(diskQueue);

    }

    void ThrowDisk()
    {
        if (diskQueue.Count != 0)
        {
            GameObject disk = diskQueue.Dequeue();

            /** 
             * 以下几句代码是随机确定飞碟出现的位置 
             */

            Vector3 position = new Vector3(0, 0, 0);
            float y = UnityEngine.Random.Range(0f, 3f);
            position = new Vector3(-disk.GetComponent<DiskData>().direction.x * 7, y, 0);
            disk.transform.position = position;

            disk.SetActive(true);
        }

    }

    public void LoadResources()
    {
        //DiskFactory df = Singleton<DiskFactory>.Instance;  
        //df.init(diskNumber);  
        Instantiate(Resources.Load<GameObject>("Prefabs/ground"));
    }


    public void GameOver()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(700, 300, 400, 400), "GAMEOVER");

    }

    public int GetScore()
    {
        return scoreRecorder.score;
    }

    public GameState getGameState()
    {
        return gameState;
    }

    public void setGameState(GameState gs)
    {
        gameState = gs;
    }

    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                scoreRecorder.Record(hit.collider.gameObject);

                /** 
                 * 如果飞碟被击中，那么就移到地面之下，由工厂负责回收 
                 */

                hit.collider.gameObject.transform.position = new Vector3(0, -5, 0);
            }

        }
    }
}