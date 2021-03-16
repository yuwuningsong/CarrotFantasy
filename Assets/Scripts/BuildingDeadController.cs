using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDeadController : MonoBehaviour
{
    [SerializeField] int health = 0;                // 血量
    [SerializeField] bool isDead = false;           // 是否死亡
    [SerializeField] GameObject crackedBuilding = null;     // 废墟物体
    [SerializeField] GameObject explosion = null;   // 爆炸特效
    [SerializeField] AudioClip clip;                // 爆炸音效
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
        Dead();
    }

    // 判断死亡状态
    void IsDead()
    {
        if (health <= 0) isDead = true;
        // TO DO: UI血条清零
    }

    // 播放死亡动画及音效
    void Dead()
    {
        if (isDead)
        {
            Debug.Log("The building is DEAD!");
            explosion.SetActive(true);
            // TO DO: 修改更好的3D音效播放
            AudioManager.audioManager.PlayAudio(clip, new Vector3(220, 127, -225)/*gameObject.transform.position*/);
            Destroy();
        }
    }

    // 销毁房屋
    void Destroy()
    {
        gameObject.SetActive(false);
        crackedBuilding.SetActive(true);
    }
}
