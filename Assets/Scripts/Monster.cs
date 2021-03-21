using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 10;
    private Transform[] positions;
    private int index = 0;

    public GameObject explosionEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.positions;
    }

    //移动
    void monsterAction()
    {
        if (index > positions.Length - 1)
            return;//怪物已经到达目标位置，游戏失败

        //两个位置相减得到移动方向,nomalized取得该方向的单位向量
        transform.Translate((-positions[index].position + transform.position).normalized * Time.deltaTime * speed);
        if(Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        monsterAction();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Building")
        {
            col.GetComponent<BuildingHurtController>().ReduceHealth();
            //GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
