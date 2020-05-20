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
        Debug.LogError("Jestem here");
        int position = 0;
        int length = results.Length - 1;
        for(int i = 0; i < length + 1;i++)
        {
            if(results[i]<score)
            {
                position = i;
                break;
            }
        }

        for (int i = 0; i < length + 1; i++)
        {
            Debug.LogError(names[i] + " " + results[i]);
        }

        while (length > position +1)
        {
            results[length] = results[length - 1];
            names[length] = names[length - 1];
            length--;
        }
        results[position] = score;
        names[position] = name;
        
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
