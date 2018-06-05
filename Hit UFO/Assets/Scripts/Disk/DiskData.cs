/* 
 * 这个文件是用来保存飞碟的一些信息， 
 * DiskData作为组件挂载在飞碟上 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskData : MonoBehaviour
{
    public int type;
    public Vector3 size;
    public Color color;
    public float speed;
    public Vector3 direction;
    public SSAction action;
}