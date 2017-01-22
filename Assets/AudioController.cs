using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public Animator animator;
    AudioSource ASa;
    AudioSource ASb;
    AudioSource ASc;
    AudioSource ASd;
    public AudioClip PreLaunch;
    public AudioClip Launch;
    public AudioClip Epic1;
    public AudioClip Epic2;
    public AudioClip Ambient;
    public AudioClip Ocean;
    public float MusicVolume = 1.0f;
    AudioClip[] tracks;
    bool started = false;
    PlayerLaunch pLaunch;

    void Start()
    {
        pLaunch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
        tracks = new AudioClip[10];
        tracks[0] = PreLaunch;
        tracks[1] = Launch;
        tracks[2] = Epic1;
        tracks[3] = Epic2;
        tracks[4] = Ambient;
        tracks[5] = Ocean;

        ASa = gameObject.AddComponent<AudioSource>();
        ASb = gameObject.AddComponent<AudioSource>();
        ASc = gameObject.AddComponent<AudioSource>();
        ASd = gameObject.AddComponent<AudioSource>();

        ASa.volume = MusicVolume;
        ASa.clip = Ambient;
        ASa.Play();

        ASb.volume = 0.0f;

        ASc.clip = Ocean;
        ASc.volume = 0.4f;
        ASb.loop = ASa.loop = true;
        ASc.loop = true;
        ASc.Play();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !started)
        {
            animator.SetTrigger("Burp");
            StartCoroutine(switchTrack(0));
            StartCoroutine(BlastOff());
            started = true;
        }


    }

    private IEnumerator Crossfade (AudioSource a, AudioSource b, float seconds)
    {
        float step_interval = seconds / 20.0f;
        float vol_interval = MusicVolume / 20f;

        b.Play();

        for(int i = 0; i < 20; i++)
        {
            a.volume -= vol_interval;
            b.volume += vol_interval;

            yield return new WaitForSeconds(step_interval);
        }

        a.Stop();
    }

    private IEnumerator BlastOff()
    {
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(switchTrack(1));
        yield return new WaitForSeconds(2.0f);
        pLaunch.SendMessage("Launch", 1.0f);
        Camera.main.GetComponent<ParallaxController>().SendMessage("StartLerp");
        StartCoroutine(switchTrack(2));
        yield return new WaitForSeconds(12.0f);
        StartCoroutine(switchTrack(3));
        yield return new WaitForSeconds(24.0f);
        StartCoroutine(switchTrack(3));
        yield return new WaitForSeconds(24.0f);
        StartCoroutine(switchTrack(3));
    }

    private IEnumerator switchTrack(int i)
    {
        bool play_a = true;
        if (ASb.volume == 0.0f) play_a = false;

        if(play_a)
        {
            ASa.clip = tracks[i];
            yield return StartCoroutine(Crossfade(ASb, ASa, 1.0f));
        }
        else
        {
            ASb.clip = tracks[i];
            yield return StartCoroutine(Crossfade(ASa, ASb, 1.0f));
        }
    }
}
