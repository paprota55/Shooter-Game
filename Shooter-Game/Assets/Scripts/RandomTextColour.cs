using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class RandomTextColour : MonoBehaviour
{
    [SerializeField]
    Text waveCounter;

    [SerializeField]
    Text waveInc;

    [SerializeField]
    MonsterSpawner spawner;

    public float counterDelay;
    public float IncDelay;

    public float del1 = 1f;
    public float del2 = 3f;

    private void Start()
    {
        counterDelay = 0;
        IncDelay = 0;
    }

    private void Update()
    {
        if(spawner.getState() == State.COUNT)
        {
            if (counterDelay + del1 < Time.time)
            {
                ChangeColour(waveCounter);
                counterDelay = Time.time;
            }


        }
        if (spawner.getState() == State.SPAWN)
        {
            if (IncDelay + del2 < Time.time)
            {
                ChangeColour(waveInc);
                IncDelay = Time.time;
            }
        }
    }

    void ChangeColour(Text text)
    {
        text.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

}
