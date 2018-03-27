
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{

    private int turn = 1;   //记录是谁的回合  
    private int[,] state = new int[3, 3];    //九方格数据  
    public GUIStyle customButton;

    //参数初始化  
    void Start()
    {
        reset();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(370, 300, 100, 50), "Reset"))
            reset();
        int result = check();
        if (result == 1)
        {
            GUI.Label(new Rect(400, 230, 100, 50), "O wins!");
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(400, 230, 100, 50), "X wins!");
        }
        else if (result == 3)
        {
            GUI.Label(new Rect(370, 230, 100, 50), "It ends in a draw");
        }
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (state[i, j] == 1)
                    GUI.Button(new Rect(i * 50+350, j * 50, 50, 50), "O");
                if (state[i, j] == 2)
                    GUI.Button(new Rect(i * 50+350, j * 50, 50, 50), "X");
                if (GUI.Button(new Rect(i * 50+350, j * 50, 50, 50), ""))
                {
                    if (result == 0)
                    {
                        if (turn == 1)
                            state[i, j] = 1;
                        else
                            state[i, j] = 2;
                        turn = -turn;
                    }
                }
            }
        }
    }

    //重置参数  
    void reset()
    {
        turn = 1;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                state[i, j] = 0;
            }
        }
    }

    //判断游戏结束条件  
    int check()
    {
        bool full = true;
        // 横向连线  
        for (int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                if (state[i, j] == 0)
                {
                    full = false;
                    break;
                }
            }
            if (state[i, 0] != 0 && state[i, 0] == state[i, 1] && state[i, 1] == state[i, 2])
            {
                return state[i, 0];
            }
        }
        //纵向连线  
        for (int j = 0; j < 3; ++j)
        {
            if (state[0, j] != 0 && state[0, j] == state[1, j] && state[1, j] == state[2, j])
            {
                return state[0, j];
            }
        }
        //斜向连线  
        if (state[1, 1] != 0 &&
            state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2] ||
            state[0, 2] == state[1, 1] && state[1, 1] == state[2, 0])
        {
            return state[1, 1];
        }
        if (full)
        {
            return 3;
        }
        return 0;
    }
}


