using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int status = 0;
    GUIStyle style;
    GUIStyle buttonStyle;
    private float time = 0;
    private bool isIni=false;

    void Start()
    {
        action = Director.getInstance().CurrentSceneController as IUserAction;

        style = new GUIStyle();
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 30;
        action.IsStop = true;
    }
    void Update()
    {
        if (!action.IsStop)
            time += Time.deltaTime;
    }
    void OnGUI()
    {
        if (isIni == false)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Start", buttonStyle))
            {
                action.IsStop = false;
                isIni = true;
            }
        }
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Time Left:" + Mathf.RoundToInt(60 - time));
        if (Mathf.RoundToInt(time) == 60)
        {
            action.IsStop = true;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Timeout!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                time = 0;
                action.IsStop = false;
                status = 0;
                action.Restart();
            }
            return;
        }
        if (status == 1)
        {
            action.IsStop = true;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                status = 0;
                action.Restart();
                time = 0;
            }
        }
        else if (status == 2)
        {
            action.IsStop = true;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                status = 0;
                action.Restart();
                time = 0;
            }
        }
    }
}