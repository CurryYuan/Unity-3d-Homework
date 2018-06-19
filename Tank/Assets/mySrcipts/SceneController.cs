using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SceneController : MonoBehaviour, IUserAction
{
    public GameObject player;//玩家坦克

    private bool gameOver = false;//游戏是否结束 

    private int enemyConut = 6;//游戏的npc数量
    private myFactory mF;//工厂


    void Awake()
    {//一些初始的设置
        GameDirector director = GameDirector.getInstance();
        director.currentSceneController = this;
        mF = Singleton<myFactory>.Instance;
        player = mF.getPlayer();
    }
    void Start()
    {
        for (int i = 0; i < enemyConut; i++)
        {//获取npc坦克
            mF.getTank();
        }
        //Player.destroyEvent += setGameOver;//如果玩家坦克被摧毁，则设置游戏结束
    }

    void Update()
    {
        if (player.activeSelf == false)
        {
            gameOver = true;
        }
    }

    public Vector3 getPlayerPos()
    {//返回玩家坦克的位置
        return player.transform.position;
    }

    public bool isGameOver()
    {//返回游戏是否结束
        return gameOver;
    }
    public void setGameOver()
    {//设置游戏结束
        gameOver = true;
    }

}
