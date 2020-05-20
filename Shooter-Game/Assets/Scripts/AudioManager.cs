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
    private float sfxVolume;
    private float musicVolume;
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
        float[] data = DataManager.LoadVolume();
        sfxVolume = data[0];
        musicVolume = data[1];
        Debug.LogError(sfxVolume + " " + musicVolume);
        for (int i = 0; i<soundList.Length;i++)
        {
            GameObject audioObject = new GameObject(i + "." + soundList[i].name);
            audioObject.transform.SetParent(this.transform);
            soundList[i].SetSource(audioObject.AddComponent<AudioSource>());
            if(soundList[i].loop) soundList[i].SetVolume(musicVolume);
            else soundList[i].SetVolume(sfxVolume);
        }
        manager.Play("MenuMusic");
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

    public void StopAll()
    {
        for (int i = 0; i < soundList.Length; i++)
        {

            soundList[i].Stop();

        }
    }

    public void UpdateEffectsVolume(float vol)
    {
        for (int i = 0; i < soundList.Length; i++)
        {
            if (!soundList[i].loop)
            {
                soundList[i].SetVolume(vol);
            }
        }
        sfxVolume = vol;
    }

    public void UpdateMusicVolume(float vol)
    {
        for (int i = 0; i < soundList.Length; i++)
        {
            if (soundList[i].loop)
            {
                soundList[i].SetVolume(vol);
            }
        }
        musicVolume = vol;
    }

    public float GetEffectVolume()
    {
        return sfxVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    private void OnDestroy()
    {
        DataManager.SaveVolume(sfxVolume, musicVolume);
    }
}
