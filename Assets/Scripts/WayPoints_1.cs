using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints_1 : MonoBehaviour//ÿ����������ʱ������ͨ��static�����ȡ����·����Ȼ������ƶ�
{
    public static Transform[] positions;//�����ƶ�·������ɵ�����

    
    void Awake()
    {
        positions = new Transform[transform.childCount];

        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
