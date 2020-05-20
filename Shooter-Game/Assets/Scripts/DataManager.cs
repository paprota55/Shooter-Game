using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataManager
{
    public static void SaveResult(int score, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Highscores.hig";
        FileStream stream = new FileStream(path, FileMode.Create);

    }

    public static void SaveHighscoreObject(Highscores high)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "F:/Shooter-Game/Highscores.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, high);
        stream.Close();
    }

    public static Highscores LoadHighscores()
    {
        string path = "F:/Shooter-Game/Highscores.fun";
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
