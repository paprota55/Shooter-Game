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
