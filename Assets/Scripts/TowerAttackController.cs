using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackController : MonoBehaviour
{
    public List<GameObject> monsters = new List<GameObject>();
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "monster")
        {
            monsters.Add(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "monster")
        {
            monsters.Remove(col.gameObject);
        }
    }
    //多少秒攻击一次
    public int attackRateTime = 1;
    private float timer = 0;
    public GameObject bulletPrefab;

    public Transform firePosition;

    void Start()
    {
        timer = attackRateTime;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(monsters.Count >0 &&timer >= attackRateTime)
        {
            timer -= attackRateTime;
            Attack();
        }
    }

    void Attack()
    {
       GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        bullet.GetComponent<Bullet>().SetTarget(monsters[0].transform); 
    }
}

