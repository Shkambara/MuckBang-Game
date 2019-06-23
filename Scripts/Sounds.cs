using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
    public static AudioClip eat, dong, hit, death;
    static AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        eat = Resources.Load<AudioClip>("eat");
        dong = Resources.Load<AudioClip>("gong");
        hit = Resources.Load<AudioClip>("hit");
        death = Resources.Load<AudioClip>("end");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "eat":
                audioSource.PlayOneShot(eat);
                break;
            case "end":
                audioSource.PlayOneShot(death);
                break;
            case "hit":
                audioSource.PlayOneShot(hit);
                break;
            case "gong":
                audioSource.PlayOneShot(dong);
                break;
        }
    }
}
