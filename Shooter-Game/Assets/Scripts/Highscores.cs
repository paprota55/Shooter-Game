using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Highscores
{
    string[] names;
    int[] results;

    public Highscores()
    {
        names = new string[5];
        results = new int[5];
    }

    public Highscores(string[] _names, int[] _results)
    {
        names = _names;
        results = _results;
    }

    public string[] GetNames()
    {
        return names;
    }

    public int[] GetResults()
    {
        return results;
    }

    public void UpdateResults(int score, string name)
    {
        
    }
    public void AddNoName()
    {
        for(int i = 0;i<5;i++)
        {
            names[i] = "Unknown";
            results[i] = 0;
        }
    }

    public void PrintAll()
    {
        for(int i = 0; i <results.Length;i++)
        {
            Debug.LogError(names[i] + " " + results[i]);
        }
    }
}
