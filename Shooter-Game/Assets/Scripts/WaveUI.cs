using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    Color[] colorTable;

    [SerializeField]
    MonsterSpawner wave;

    [SerializeField]
    Animator waveAnim;

    [SerializeField]
    Text counter;

    [SerializeField]
    Text waveNumber;
    void Start()
    {        
        if(wave == null || waveAnim == null || counter == null || waveNumber == null)
        {
            Debug.LogError("Some problems in Start methods in WaveUI");
            this.enabled = false;
        }
        StartCoroutine(changeColor());
    }

    
    void Update()
    {
        switch (wave.getState())
        {
            case State.COUNT:
                UpdateCounter();
                break;
            case State.SPAWN:
                UpdateSpawner();
                break;
        }
    }


    void UpdateSpawner()
    {
        waveAnim.SetBool("Counter", false);
        waveAnim.SetBool("WaveInc", true);
        waveNumber.text = ((int)wave.getWaveNumber() + 1).ToString();
        
    }

    void UpdateCounter()
    {
        waveAnim.SetBool("Counter", true);
        waveAnim.SetBool("WaveInc", false);
        counter.text = ((int)wave.getCounter() + 1).ToString();
    }

    IEnumerator changeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            counter.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }
}
