using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 20;
    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;   
    }

     void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
