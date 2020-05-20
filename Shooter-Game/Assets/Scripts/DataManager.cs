using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataManager
{
    public static void SaveNewHighscore(int score, string name)
    {
        Highscores table = LoadHighscores();
        table.UpdateResults(score, name);
        SaveHighscoreObject(table);
    }

    private static void SaveHighscoreObject(Highscores high)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Highscores.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, high);
        stream.Close();
    }

    public static void SaveVolume(float effect, float music)
    {
        Debug.LogError("Zapis");
        float[] data = new float[2];
        data[0] = effect;
        data[1] = music;

        Debug.LogError(data[0] + " " + data[1]);

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Volume.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadVolume()
    {
        string path = Application.persistentDataPath + "/Volume.fun";
        float[] data;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Position = 0;
            data = formatter.Deserialize(stream) as float[];
            stream.Close();
            Debug.LogError("Load z pliku");
        }
        else
        {
            data = new float[2];
            data[0] = 1f;
            data[1] = 1f;
            Debug.LogError("Nie ma danych");
        }
        Debug.LogError(data[0] + " " + data[1]);

        return data;
    }

    public static Highscores LoadHighscores()
    {
        string path = Application.persistentDataPath + "/Highscores.fun";
        Highscores data;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Position = 0;
            data = formatter.Deserialize(stream) as Highscores;
            stream.Close();
        }
        else
        {
            data = new Highscores();
            data.AddNoName();
            SaveHighscoreObject(data);
        }
        
        return data;
    }
}
