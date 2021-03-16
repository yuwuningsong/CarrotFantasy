using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;        // 单例

    private void Awake()
    {
        audioManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 播放音效
    public void PlayAudio(AudioClip clip, Vector3 position)
    {
        Debug.Log("Play Audio!");
        AudioSource.PlayClipAtPoint(clip, position);
    }
}
