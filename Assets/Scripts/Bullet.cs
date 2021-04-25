using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public float speed = 40;
    private Transform target;

    public void SetTarget(Transform _target)
    {

        this.target = _target;

    }

    void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
        }
        transform.LookAt(target.position);
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
