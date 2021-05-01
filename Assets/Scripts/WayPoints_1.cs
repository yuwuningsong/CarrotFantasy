using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints_1 : MonoBehaviour//每个怪物生成时，可以通过static数组读取他的路径点然后进行移动
{
    public static Transform[] positions;//怪物移动路径点组成的数组

    
    void Awake()
    {
        positions = new Transform[transform.childCount];

        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
