using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackController : MonoBehaviour
{
    public List<GameObject> monsters = new List<GameObject>();
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("monster"))
        {
            monsters.Add(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("monster"))
        {
            monsters.Remove(col.gameObject);
        }
    }
    //多少秒攻击一次
    public int attackRateTime = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform head;
    public Transform firePosition;
   

    void Start()
    {
        timer = attackRateTime;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (monsters.Count > 0 && timer >= attackRateTime)
        {
            timer = 0;
            Attack();
        }
        if (monsters.Count > 0 && monsters[0] != null)
        {
            Vector3 targetPosition = monsters[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition );
        }

        
    }

    void Attack()
    {
        if (monsters[0] == null)
        {
            UpdateMonsters();
        }
        if (monsters.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(monsters[0].transform.GetChild(2));
        }
        else
        {
            timer = attackRateTime;
        }
    }
    

    void UpdateMonsters()
    {
        List<int> emptyIndex = new List<int>();
        for(int index = 0; index < monsters.Count; index++)
        {
            if (monsters[index] == null)
            {
                emptyIndex.Add(index);
            }
        }
        for(int i = 0; i < emptyIndex.Count; i++)
        {
            monsters.RemoveAt(emptyIndex[i] - i);
        }
    }
}

