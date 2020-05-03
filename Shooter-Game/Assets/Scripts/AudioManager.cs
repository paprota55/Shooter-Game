using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;

    public void Play()
    {
        source.Play();
    }

    public void SetSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = clip;
    }

    public void SetVolume(float _volume)
    {
        source.volume = _volume;
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager manager;

    [SerializeField]
    public Sound[] soundList;
    public float volume = 1.0f;
    private void Awake()
    {
        if (manager == null) manager = this;
        else Debug.Log("Too many AudioManagers");
    }

    private void Start()
    {
        for (int i = 0; i<soundList.Length;i++)
        {
            GameObject audioObject = new GameObject(i + "." + soundList[i].name);
            audioObject.transform.SetParent(this.transform);
            soundList[i].SetSource(audioObject.AddComponent<AudioSource>());
            soundList[i].SetVolume(volume);
        }
    }

    public void Play(string name)
    {
        for(int i = 0; i<soundList.Length;i++)
        {
            if(soundList[i].name == name)
            {
                soundList[i].Play();
                return;
            }
        }
    }
}
