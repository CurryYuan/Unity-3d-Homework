using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    bool isFirst = true;
    private GUIStyle style = new GUIStyle();
    // Use this for initialization  
    void Start()
    {
        action = Director.getInstance().currentSceneControl as IUserAction;
        style.fontSize = 20;
    }

    private void OnGUI()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Vector3 pos = Input.mousePosition;
            action.hit(pos);
            GUI.skin.button.fontSize = 20;
        }

        GUI.Label(new Rect(Screen.width-200, 0, 400, 400), "Score: "+action.GetScore().ToString(),style);

        if (isFirst && GUI.Button(new Rect(Screen.width/2-45, Screen.height/2-45, 90, 90), "Start"))
        {
            isFirst = false;
            action.setGameState(GameState.ROUND_START);
        }

        if (!isFirst && action.getGameState() == GameState.ROUND_FINISH && GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 45, 150, 90), "Next Round"))
        {
            action.setGameState(GameState.ROUND_START);
        }

    }


}