using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataManager
{
    static string playerStatsPath = Application.persistentDataPath + "/PlayerStats.fun";
    static string playerPath = Application.persistentDataPath + "/Player.fun";
    static string highscoresPath = Application.persistentDataPath + "/Highscores.fun";
    static string volumePath = Application.persistentDataPath + "/Volume.fun";

    public static bool CheckFilesToLoad()
    {
        if (File.Exists(playerStatsPath))
            return true;

        return false;
    }
    /// //////////////////////////////////////////////////////

    /// /////////////////PLAYER///////////////////////////////

    public static void SavePlayer(Vector3 data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerPath, FileMode.Create);
        PlayerMemory memory = new PlayerMemory(data);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    public static PlayerMemory LoadPlayer()
    {
        if (File.Exists(playerPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerPath, FileMode.Open);
            stream.Position = 0;
            PlayerMemory memory = formatter.Deserialize(stream) as PlayerMemory;
            stream.Close();
            return memory;
        }
        else
        {
            return null;
        }
    }


    /// //////////////////////////////////////////////////////

    /// /////////////////PLAYERSTATS//////////////////////////
    public static void SavePlayerStats(PlayerStats data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerStatsPath, FileMode.Create);
        PlayerStatsMemory memory = new PlayerStatsMemory(data);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    public static PlayerStatsMemory LoadPlayerStats()
    {
        if (File.Exists(playerStatsPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerStatsPath, FileMode.Open);
            stream.Position = 0;
            PlayerStatsMemory memory = formatter.Deserialize(stream) as PlayerStatsMemory;
            stream.Close();
            return memory;
        }
        else
        {
            return null;
        }
    }
    /// /////////////////////////////////////////////////////

    /// /////////////////VOLUME//////////////////////////////
    public static void SaveVolume(float effect, float music)
    {
        float[] data = new float[2];
        data[0] = effect;
        data[1] = music;

        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/Volume.fun";
        FileStream stream = new FileStream(volumePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadVolume()
    {
        //string path = Application.persistentDataPath + "/Volume.fun";
        float[] data;
        if (File.Exists(volumePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(volumePath, FileMode.Open);
            stream.Position = 0;
            data = formatter.Deserialize(stream) as float[];
            stream.Close();
        }
        else
        {
            data = new float[2];
            data[0] = 1f;
            data[1] = 1f;
        }

        return data;
    }
    /// ////////////////////////////////////////////////////

    /// /////////////////HIGHSCORE//////////////////////////

    public static void SaveNewHighscore(int score, string name)
    {
        Highscores table = LoadHighscores();
        table.UpdateResults(score, name);
        SaveHighscoreObject(table);
    }

    private static void SaveHighscoreObject(Highscores data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/Highscores.fun";
        FileStream stream = new FileStream(highscoresPath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Highscores LoadHighscores()
    {
        //string path = Application.persistentDataPath + "/Highscores.fun";
        Highscores data;
        if (File.Exists(highscoresPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(highscoresPath, FileMode.Open);
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

    /// ////////////////////////////////////////////////////
}
