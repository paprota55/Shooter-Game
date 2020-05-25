using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Store highscores list
[System.Serializable]
public class HighscoresMemory
{
    ///names in highscores
    string[] names;
    ///results in highscores
    int[] results;

    public HighscoresMemory()
    {
        names = new string[5];
        results = new int[5];
    }

    public HighscoresMemory(string[] _names, int[] _results)
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

    ///Update highscores - write new record and override if highscores table is full
    public void UpdateResults(int score, string name)
    {
        int position = 50;
        int length = results.Length - 1;

        for (int i = 0; i < length + 1; i++)
        {
            if (results[i] < score)
            {
                position = i;

                break;
            }
        }

        if (position < length)
        {
            while (length > position)
            {
                results[length] = results[length - 1];
                names[length] = names[length - 1];
                length--;
            }
            results[position] = score;
            names[position] = name;
        }

    }

    ///fill records in table - if empty
    public void AddNoName()
    {
        for(int i = 0;i<5;i++)
        {
            names[i] = "Unknown";
            results[i] = 0;
        }
    }
}
