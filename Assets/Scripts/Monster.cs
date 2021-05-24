using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{
    public float speed = 10;
    private Transform[] positions;
    private Transform[] positions1;
    private Transform[] positions2;
    private int index = 0;
   
    public Slider hpSlider; //Ѫ��
    [SerializeField] int maxHp = 150;//���Ѫ��
    [SerializeField] int currentHp = 150;//��ǰѪ��
    public Transform targetPosition;

    public GameObject explosionEffectPrefab;

    public bool IsDead { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        positions1 = WayPoints_1.positions;
        positions2 = WayPoints_2.positions;
        currentHp = maxHp;
        System.Random rd = new System.Random();
        if (rd.NextDouble() > 0.5)
        {
            positions = positions1;
        }
        else
        {
            positions = positions2;
        }
    }

    //�ƶ�
    void monsterAction()
    {
        
        if (index > positions.Length - 1)
            return;//�����Ѿ�����Ŀ��λ�ã���Ϸʧ��

        //����λ������õ��ƶ�����,nomalizedȡ�ø÷���ĵ�λ����
        Vector3 tmp = (positions[index].position - transform.position).normalized;
        transform.Rotate(0, Vector3.Angle(transform.forward, tmp), 0);
        transform.Translate(tmp * Time.deltaTime * speed, Space.World);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        monsterAction();
        if (IsDead) Dead();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Building")
        {
            col.GetComponent<BuildingHurtController>().ReduceHealth();
            //GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            GameManager.gameManager.DestroyMonster(gameObject);
            Destroy(this.gameObject);
        }
    }

    //�ܵ��˺�
    public void TakeDamage(int damage)
    {
        if (currentHp <= 0)
        {
            IsDead = true;
            return;
        }
        else
        {
            currentHp -= damage;
            hpSlider.value = (float)currentHp / maxHp;
            if (currentHp <= 0)
            {
                IsDead = true;
            }

        }
    }

    //��������
    void Dead()
    {
        gameObject.GetComponent<MonsterCoinController>().CreateCoins();
        GameManager.gameManager.DestroyMonster(gameObject);
        Destroy(this.gameObject);
    }
}
