using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUserGUI : MonoBehaviour {
	IUserAction action;
	// Use this for initialization
	void Start () {
		action = GameDirector.getInstance().currentSceneController as IUserAction;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!action.isGameOver()) {

		}
	}
}
