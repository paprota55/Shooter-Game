using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

///Sound class which store information about clip to play
[System.Serializable]
public class Sound
{
    ///sound name
    public string name;

    ///sound clip which is playing
    public AudioClip clip;

    ///Source from sound will be broadcast
    private AudioSource source;

    ///if sound should be repeatable all time
    public bool loop;

    ///Start playing audio from Clip
    public void Play()
    {
        source.Play();
    }

    ///Stop playing audio
    public void Stop()
    {
        source.Stop();
    }

    ///Set audio source
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

    ///Check if sound actually is playing
    public bool isPlaying()
    {
        return source.isPlaying;
    }
}
public class AudioManager : MonoBehaviour
{
    ///audiomanager instance - singleton project template
    public static AudioManager manager;

    ///List of sounds objects
    [SerializeField]
    public Sound[] soundList;

    ///Volumes
    private float sfxVolume;
    private float musicVolume;

    ///Create reference to manager, use singleton project template, and set not destroy if change scene
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

    ///Create sound objects and set initial volumes, start menu music sound
    private void Start()
    {
        float[] data = DataManager.LoadVolume();
        sfxVolume = data[0];
        musicVolume = data[1];

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

    ///Start playing sound which name is in argument
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

    ///Stop playing sound which name is in argument
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

    ///Stop all playing sounds
    public void StopAll()
    {
        for (int i = 0; i < soundList.Length; i++)
        {

            soundList[i].Stop();

        }
    }

    ///update sfx volume in all sound objects
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

    ///update music volume in all sound objects
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

    ///Before destroy save volumes to file
    private void OnDestroy()
    {
        DataManager.SaveVolume(sfxVolume, musicVolume);
    }
}
