using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
    float rz, rx, ry;
    // Use this for initialization  
    void Start()
    {
        speed = Random.Range(10, 40);
        rx = Random.Range(0, 20);
        ry = Random.Range(0, 20);
        rz = Random.Range(0, 20);
    }

    // Update is called once per frame  
    void Update()
    {
        Vector3 axis = new Vector3(0, ry, rz);
        this.transform.RotateAround(new Vector3(0, 0, 0), axis, speed * Time.deltaTime);
    }
}
