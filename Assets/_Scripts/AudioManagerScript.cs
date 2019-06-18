using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public static AudioClip mine;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        mine = Resources.Load<AudioClip> ("StoneBlock");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "StoneBlock":
                audioSrc.PlayOneShot(mine);
                break;
        }
    }
}
