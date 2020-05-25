using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Class to modify and set Wave time/incoming animation
public class WaveUI : MonoBehaviour
{
    ///Monster spawner to get state of spawner
    [SerializeField]
    MonsterSpawner wave;

    ///Animator to controll animation stream
    [SerializeField]
    Animator waveAnim;

    ///To display time to next wave
    [SerializeField]
    Text counter;

    ///Information - wave is spawning
    [SerializeField]
    Text waveNumber;
    void Start()
    {        
        if(wave == null || waveAnim == null || counter == null || waveNumber == null)
        {
            Debug.LogError("Some problems in Start methods in WaveUI");
            this.enabled = false;
        }
    }

    /// Depending on the state spawner, choose method
    void Update()
    {
        switch (wave.WaveState)
        {
            case State.COUNT:
                UpdateCounter();
                break;
            case State.SPAWN:
                UpdateSpawner();
                break;
        }
    }

    ///Update number of wave and choose animation to display in animator
    void UpdateSpawner()
    {
        waveAnim.SetBool("Counter", false);
        waveAnim.SetBool("WaveInc", true);
        waveNumber.text = ((int)wave.WaveNumber + 1).ToString();
        
    }

    ///Update time to next spawn and choose animation to display in animator
    void UpdateCounter()
    {
        waveAnim.SetBool("Counter", true);
        waveAnim.SetBool("WaveInc", false);
        counter.text = ((int)wave.getCounter() + 1).ToString();
    }
}
