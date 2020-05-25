using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

///Additional class which changing colour of text
public class RandomTextColour : MonoBehaviour
{
    ///Text to change colour
    [SerializeField]
    Text waveCounter;

    ///Text to change colour
    [SerializeField]
    Text waveInc;

    ///Monster spawner to get state of spawn
    [SerializeField]
    MonsterSpawner spawner;

    ///Actually time
    public float counterDelay;
    public float IncDelay;

    ///colour change delay
    public float del1 = 1f;
    public float del2 = 3f;

    private void Start()
    {
        counterDelay = 0;
        IncDelay = 0;
    }

    ///Check if wave state is suitable and time is greater than delay time
    private void Update()
    {
        if(spawner.WaveState == State.COUNT)
        {
            if (counterDelay + del1 < Time.time)
            {
                ChangeColour(waveCounter);
                counterDelay = Time.time;
            }


        }
        if (spawner.WaveState == State.SPAWN)
        {
            if (IncDelay + del2 < Time.time)
            {
                ChangeColour(waveInc);
                IncDelay = Time.time;
            }
        }
    }

    ///Change colour of text
    void ChangeColour(Text text)
    {
        text.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

}
