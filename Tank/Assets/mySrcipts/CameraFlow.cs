using System;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public GameObject role;
    public float roate_Speed = 1.5f;
    SceneController sceneController;
    void Start()
    {
        transform.parent = role.transform;
        sceneController = GameDirector.getInstance().currentSceneController;

    }
    void FixedUpdate()
    {
        transform.position = role.transform.position;
        transform.Translate(new Vector3(0, 4, -6));

        if (!sceneController.isGameOver())
        {
            float mousX = Input.GetAxis("Mouse X") * roate_Speed;       //得到鼠标移动距离  
            role.transform.Rotate(new Vector3(0, mousX, 0));                //旋转  
        }
    }
}