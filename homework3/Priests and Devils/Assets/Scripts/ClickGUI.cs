using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class ClickGUI : MonoBehaviour
{
    IUserAction action;
    MyCharacterController characterController;

    public void setController(MyCharacterController characterCtrl)
    {
        characterController = characterCtrl;
    }

    void Start()
    {
        action = Director.getInstance().CurrentSceneController as IUserAction;
    }

    void OnMouseDown()
    {
        if (action.IsStop)
            return;
        if (gameObject.name == "boat")
        {
            action.moveBoat();
        }
        else
        {
            action.characterIsClicked(characterController);
        }
    }
    
}