using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    //TODO: you will need more data than this, like clips to play and a way to know which clip is playing
    protected AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
        int i = 0;
    int looping = 0;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = clips[0];
        //TODO; prep the boom box
    }

    public void PlayClip()
    {
        //TODO; this is where you might want to setup and ensure the desire clip is playing on the source
    }




    public override void OnUse()
    {

        base.OnUse();
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            looping = 0;
        }
        else
        {
            if (clips.Length - 1 > i)
            {
                audioSource.clip = clips[i];
                audioSource.Play();
                i++;
            }
            else
            {
                i = 0;
                audioSource.clip = clips[i];
                audioSource.Play();
            }
            looping = 1;
        }

        //TODO; this where we need to go to next track and start and stop playing
    }
    private void Update()
    {
        if (looping == 1)
        {
            if(!audioSource.isPlaying)
            {
                if (clips.Length - 1 > i)
                {
                    i++;
                    audioSource.clip = clips[i];
                    audioSource.Play();
                }
                else
                {
                    i = 0;
                    audioSource.clip = clips[i];
                    audioSource.Play();
                }
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BowlingBall")
        {
            Destroy(gameObject);
        }
    }

}
