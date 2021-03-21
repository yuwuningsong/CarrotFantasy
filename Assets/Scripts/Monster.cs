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

    //�ƶ�
    void monsterAction()
    {
        if (index > positions.Length - 1)
            return;//�����Ѿ�����Ŀ��λ�ã���Ϸʧ��

        //����λ������õ��ƶ�����,nomalizedȡ�ø÷���ĵ�λ����
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
