using System;
using UnityEngine;

public class FPPCamera : MonoBehaviour
{
    public GameObject role;
    public float roate_Speed = 2.0f;
    public FirstSceneController sceneController;
    void Start()
    {
        transform.parent = role.transform;
        sceneController = (FirstSceneController)SSDirector.GetInstance().CurrentScenceController;
    }
    void FixedUpdate()
    {
        transform.position = role.transform.position;
        transform.Translate(new Vector3(0, 1, 0.5f));
        if (!sceneController.GetGameover())
        {
            float mousX = Input.GetAxis("Mouse X") * roate_Speed;       //得到鼠标移动距离  
            role.transform.Rotate(new Vector3(0, mousX, 0));                //旋转  
        }
    }
}