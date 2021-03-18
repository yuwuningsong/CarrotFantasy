using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHurtController : MonoBehaviour
{
    public int health = 10;
    [SerializeField] int totalHealth = 10;
    public AudioClip clip = null;
    public Slider healthVector = null;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    
    public void ReduceHealth()
    {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);

        if (health > 0)
        {
            health--;
            healthVector.value =totalHealth - health;
        }
    }

}
