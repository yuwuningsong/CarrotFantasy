using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiwControlller : MonoBehaviour
{
    

    public float speed = 8;
    public float mouseSpeed = 70000;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //»¬ÂÖ¿ØÖÆ´óÐ¡
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h * speed, mouse * mouseSpeed, v * speed) * Time.deltaTime * speed);

        
    }
}
