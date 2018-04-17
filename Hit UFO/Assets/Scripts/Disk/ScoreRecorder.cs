/** 
 * 这个类是用来记录玩家得分的 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{

    /** 
     * score是玩家得到的总分 
     */

    public int score;


    // Use this for initialization  
    void Start()
    {
        score = 0;

    }

    public void Record(GameObject disk)
    {
        score +=disk.GetComponent<DiskData>().type;
    }

    public void Reset()
    {
        score = 0;
    }
}