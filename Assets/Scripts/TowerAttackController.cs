using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackController : MonoBehaviour
{
    public List<GameObject> monsters = new List<GameObject>();
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("monster"))
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
    public GameObject emptyPrefab;

    public Transform firePosition ;

    void Start()
    {
        timer = attackRateTime;
        GameObject emptyObject = GameObject.Instantiate(emptyPrefab, this.transform.position, this.transform.rotation);
        firePosition = emptyObject.transform;
        firePosition.position = new Vector3(emptyObject.transform.position.x, emptyObject.transform.position.y + 7, emptyObject.transform.position.z);
        Debug.Log("设置firePosition");
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(monsters.Count >0 &&timer >= attackRateTime)
        {
            timer -= attackRateTime;
            Attack();
        }

        if (monsters.Count != 0 && monsters[0].GetComponent<Monster>().IsDead) monsters.Remove(monsters[0]);
    }

    void Attack()
    {
       GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
       // Vector3 TargetVector = new Vector3(monsters[0].transform.position.x, monsters[0].transform.position.y+3, monsters[0].transform.position.z);
        bullet.GetComponent<Bullet>().SetTarget(new Vector3(monsters[0].transform.position.x, monsters[0].transform.position.y + 3, monsters[0].transform.position.z)); 
    }
}

