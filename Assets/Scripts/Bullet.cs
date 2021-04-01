using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 50;
    private Vector3 target;

    public void SetTarget(Vector3 _target)
    {
        this.target = _target;   
    }

     void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("monster"))
        {
            collision.collider.gameObject.GetComponent<Monster>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
