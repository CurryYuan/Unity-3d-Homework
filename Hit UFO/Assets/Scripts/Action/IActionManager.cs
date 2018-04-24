using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IActionManager
{
    int DiskNumber { get; set; }
    void StartThrow(Queue<GameObject> diskQueue);
}
