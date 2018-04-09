using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCActionManager : SSActionManager, ISSActionCallback
{
    public FirstController sceneController;
    public Moveable moveable;

    // Use this for initialization  
    protected void Start()
    {
        sceneController = (FirstController)Director.getInstance().CurrentSceneController;
        sceneController.ActionManager = this;
    }

    // Update is called once per frame  

    public void OnShore(MyCharacterController characterCtrl, CoastController whichCoast)
    {
        sceneController.boat.GetOffBoat(characterCtrl.getName());

        moveable = Moveable.GetSSAction(whichCoast.getEmptyPosition());
        RunAction(characterCtrl.character, moveable, this);

        characterCtrl.getOnCoast(whichCoast);
        whichCoast.getOnCoast(characterCtrl);

    }

    public void OnBoat(MyCharacterController characterCtrl, CoastController whichCoast)
    {
        whichCoast.getOffCoast(characterCtrl.getName());

        moveable = Moveable.GetSSAction(sceneController.boat.getEmptyPosition());
        RunAction(characterCtrl.character, moveable, this);

        characterCtrl.getOnBoat(sceneController.boat);
        sceneController.boat.GetOnBoat(characterCtrl);
    }

    public void BoatMove(BoatController boat)
    {

        if (boat.to_or_from == -1)
        {
            moveable = Moveable.GetSSAction(boat.fromPosition);
            RunAction(boat.getGameobj(), moveable, this);
            boat.to_or_from = 1;
        }
        else
        {
            moveable = Moveable.GetSSAction(boat.toPosition);
            RunAction(boat.getGameobj(), moveable, this);
            boat.to_or_from = -1;
        }
    }

    public void BoatReset(BoatController boat)
    {

        if (boat.to_or_from == -1)
        {
            moveable = Moveable.GetSSAction(boat.fromPosition);
            RunAction(boat.getGameobj(), moveable, this);
            boat.to_or_from = 1;
        }

    }

    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0, string strParam = null, Object objectParam = null)
    {
        //  
    }
}