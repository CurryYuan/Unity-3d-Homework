using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class Moveable : SSAction
{

    readonly float move_speed = 20;
    static Vector3 temp;
    // change frequently
    public int moving_status;  // 0->not moving, 1->moving to middle, 2->moving to dest
    Vector3 dest;
    Vector3 middle;

    public static Moveable GetSSAction(Vector3 _dest)
    {
        Moveable action = ScriptableObject.CreateInstance<Moveable>();
        temp = _dest;
        return action;
    }

    public override void Start()
    {
        setDestination(temp);
    }

    public override void Update()
    {
        if (moving_status == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, middle, move_speed * Time.deltaTime);
            if (transform.position == middle)
            {
                moving_status = 2;
            }
        }
        else if (moving_status == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, move_speed * Time.deltaTime);
            if (transform.position == dest)
            {
                moving_status = 0;
            }
        }
    }

    public void setDestination(Vector3 _dest)
    {
        dest = _dest;
        middle = _dest;
        if (_dest.y == transform.position.y)
        {   // boat moving
            moving_status = 2;
        }
        else if (_dest.y < transform.position.y)
        {   // character from coast to boat
            middle.y = transform.position.y;
        }
        else
        {                               // character from boat to coast
            middle.x = transform.position.x;
        }
        moving_status = 1;
    }

}

