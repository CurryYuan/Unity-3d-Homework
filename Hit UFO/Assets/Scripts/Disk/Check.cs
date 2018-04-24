using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int num;
    public Emit EmitDisk;
    void OnTriggerEnter(Collider other)
    {
        EmitDisk = (Emit)other.gameObject.GetComponent<DiskData>().action;
        EmitDisk.Destory();
    }
}
