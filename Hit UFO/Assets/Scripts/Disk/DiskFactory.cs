/** 
 * 这个文件是用来生产飞碟的工厂 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{

    /** 
     * diskPrefab是用来生产飞碟的模板，保存着一个飞碟的实例 
     */

    public GameObject diskPrefab;
    public GameObject diskPrefab1;
    public GameObject diskPrefab2;

    /** 
     * used是用来保存正在使用的飞碟 
     * free是用来保存未激活的飞碟 
     */

    private List<DiskData> used = new List<DiskData>();
    private List<DiskData> free = new List<DiskData>();

    private void Awake()
    {
        diskPrefab = Instantiate(Resources.Load<GameObject>("Prefabs/disk"), Vector3.zero, Quaternion.identity);
        diskPrefab.SetActive(false);
        diskPrefab1 = Instantiate(Resources.Load<GameObject>("Prefabs/disk1"), Vector3.zero, Quaternion.identity);
        diskPrefab1.SetActive(false);
        diskPrefab2 = Instantiate(Resources.Load<GameObject>("Prefabs/disk2"), Vector3.zero, Quaternion.identity);
        diskPrefab2.SetActive(false);
    }

    /** 
     * GetDisk这个函数是用来飞碟的， 
     * 每次首次判断free那里还有没有未使用的飞碟， 
     * 有就从free那里获取，没有就生成一个飞碟 
     */

    public GameObject GetDisk(int round)
    {
        GameObject newDisk = null;

        /** 
         * 以下几句代码是用来随机生成飞碟的颜色的，并根据回合数来限制飞碟可用的颜色 
         * 第一回合智能生成黄色的飞碟，第二回合飞碟可以有黄色和红色，第三回合黄，红 
         * 黑三种颜色的飞碟都可以出现，start变量是用来改变每一回合飞碟出现的概率的 
         */

        int start = 0;
        if (round == 1) start = 100;
        if (round == 2) start = 250;
        int selectedColor = Random.Range(start, round * 499);

        if (selectedColor > 500)
        {
            round = 2;
        }
        else if (selectedColor > 300)
        {
            round = 1;
        }
        else
        {
            round = 0;
        }

        /** 
         * 根据回合数来生成相应的飞碟 
         */

        switch (round)
        {

            case 0:
                {
                    if (free.Count > 0 && free[0].type==1)
                    {
                        newDisk = free[0].gameObject;
                        free.Remove(free[0]);
                    }
                    else
                    {
                        newDisk = Instantiate(diskPrefab, Vector3.zero, Quaternion.identity);
                        newDisk.GetComponent<DiskData>().type = 1;
                    }
                    float RanX = Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);
                    newDisk.GetComponent<Renderer>().material.color = newDisk.GetComponent<DiskData>().color;
                    break;
                }
            case 1:
                {
                    if (free.Count > 0&&free[0].type==2)
                    {
                        newDisk = free[0].gameObject;
                        free.Remove(free[0]);
                    }
                    else
                    {
                        newDisk = Instantiate(diskPrefab1, Vector3.zero, Quaternion.identity);
                        newDisk.GetComponent<DiskData>().type = 2;
                    }                    
                    float RanX = Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);
                    newDisk.GetComponent<Renderer>().material.color = newDisk.GetComponent<DiskData>().color;
                    break;
                }
            case 2:
                {
                    if (free.Count > 0&&free[0].type==3)
                    {
                        newDisk = free[0].gameObject;
                        free.Remove(free[0]);
                    }
                    else
                    {
                        newDisk = Instantiate(diskPrefab2, Vector3.zero, Quaternion.identity);
                        newDisk.GetComponent<DiskData>().type = 3;
                    }                    
                    float RanX = Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);
                    newDisk.GetComponent<Renderer>().material.color = newDisk.GetComponent<DiskData>().color;
                    break;
                }
        }

        used.Add(newDisk.GetComponent<DiskData>());
        //newDisk.SetActive(true);  
        newDisk.name = newDisk.GetInstanceID().ToString();
        return newDisk;
    }

    public void FreeDisk(GameObject disk)
    {
        DiskData tmp = null;
        foreach (DiskData i in used)
        {
            if (disk.GetInstanceID() == i.gameObject.GetInstanceID())
            {
                tmp = i;
            }
        }
        if (tmp != null)
        {
            tmp.gameObject.SetActive(false);
            free.Add(tmp);
            used.Remove(tmp);
        }
    }

}