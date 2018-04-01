using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public Transform origin;
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
        this.transform.RotateAround(origin.position, axis, speed * Time.deltaTime);
    }
}
