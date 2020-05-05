using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;
    public bool loop;
    bool status;

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SetSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = clip;
        source.loop = loop;
    }

    public void SetVolume(float _volume)
    {
        source.volume = _volume;
    }

    public bool isPlaying()
    {
        return source.isPlaying;
    }
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager manager;

    [SerializeField]
    public Sound[] soundList;
    public float oldSfxVolume = 1.0f;
    public float newSfxVolume = 1.0f;
    public float newMusicVolume = 1.0f;
    public float oldMusicVolume = 1.0f;
    int menuMusic, gameMusic;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(manager!=this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        for (int i = 0; i<soundList.Length;i++)
        {
            GameObject audioObject = new GameObject(i + "." + soundList[i].name);
            if (soundList[i].name == "GameMusic") gameMusic = i;
            if (soundList[i].name == "MenuMusic") menuMusic = i;
            audioObject.transform.SetParent(this.transform);
            soundList[i].SetSource(audioObject.AddComponent<AudioSource>());
            soundList[i].SetVolume(newSfxVolume);
        }
        soundList[menuMusic].Play();
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

    public void Stop(string name)
    {
        for (int i = 0; i < soundList.Length; i++)
        {
            if (soundList[i].name == name)
            {
                soundList[i].Stop();
                return;
            }
        }
    }

    /*private void Update()
    {
        if(newSfxVolume != oldSfxVolume)
        {
            for (int i = 0; i < soundList.Length; i++)
            {
                if (soundList[i].clip.length < 10.0f)
                {
                    soundList[i].SetVolume(newSfxVolume);
                }
            }
            oldSfxVolume = newSfxVolume;
        }

        if (newMusicVolume != oldMusicVolume)
        {
            for (int i = 0; i < soundList.Length; i++)
            {
                if (soundList[i].clip.length > 10.0f)
                {
                    soundList[i].SetVolume(newMusicVolume);
                }
            }
            oldMusicVolume = newMusicVolume;
        }

        if (SceneManager.GetActiveScene().name.Equals("MenuScene"))
        {
            if (soundList[gameMusic].isPlaying())
            {
                soundList[menuMusic].Play();
                soundList[gameMusic].Stop();
            }
        }
        else
        {
            if (soundList[menuMusic].isPlaying())
            {
                soundList[menuMusic].Stop();
                soundList[gameMusic].Play();
            }
        }
    }*/
}
