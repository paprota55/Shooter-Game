using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

///Static class to load/save data to/from file
public static class DataManager
{
    ///File paths
    static string playerStatsPath = Application.persistentDataPath + "/PlayerStats.fun";
    static string playerPath = Application.persistentDataPath + "/Player.fun";
    static string highscoresPath = Application.persistentDataPath + "/Highscores.fun";
    static string shopPath = Application.persistentDataPath + "/Shop.fun";
    static string monsterSpawnerPath = Application.persistentDataPath + "/MonsterSpawner.fun";
    static string volumePath = Application.persistentDataPath + "/Volume.fun";


    ///Delete old files
    public static void DeleteOldSave()
    {
        //player stats
        if (File.Exists(playerStatsPath))
            File.Delete(playerStatsPath);

        //player
        if (File.Exists(playerPath))
            File.Delete(playerPath);

        //shop
        if (File.Exists(shopPath))
            File.Delete(shopPath);

        //monster spawner
        if (File.Exists(monsterSpawnerPath))
            File.Delete(monsterSpawnerPath);
    }

    ///Check if filepaths are good
    public static bool CheckFilesToLoad()
    {
        if (File.Exists(playerStatsPath) && File.Exists(playerPath)&&File.Exists(shopPath)&&File.Exists(monsterSpawnerPath))
            return true;

        return false;
    }

    ///Save shop data to file
    public static void SaveShop(Shop data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(shopPath, FileMode.Create);
        ShopMemory memory = new ShopMemory(data);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    ///Load shop data from file
    public static ShopMemory LoadShop()
    {
        if (File.Exists(shopPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(shopPath, FileMode.Open);
            stream.Position = 0;
            ShopMemory memory = formatter.Deserialize(stream) as ShopMemory;
            stream.Close();
            return memory;
        }
        else
        {
            return null;
        }
    }

    ///Save player data to file
    public static void SavePlayer(Vector3 data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerPath, FileMode.Create);
        PlayerMemory memory = new PlayerMemory(data);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    ///Load player data from file
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

    ///Save monsterspawner data to file
    public static void SaveMonsterSpawner(MonsterSpawner data, GameObject[] list)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(monsterSpawnerPath, FileMode.Create);
        MonsterSpawnerMemory memory = new MonsterSpawnerMemory(data, list);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    ///Load monsterspawner data from file
    public static MonsterSpawnerMemory LoadMonsterSpawner()
    {
        if (File.Exists(monsterSpawnerPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(monsterSpawnerPath, FileMode.Open);
            stream.Position = 0;
            MonsterSpawnerMemory memory = formatter.Deserialize(stream) as MonsterSpawnerMemory;
            stream.Close();
            return memory;
        }
        else
        {
            return null;
        }
    }
    
    ///Save playerstats data to file
    public static void SavePlayerStats(PlayerStats data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerStatsPath, FileMode.Create);
        PlayerStatsMemory memory = new PlayerStatsMemory(data);
        formatter.Serialize(stream, memory);
        stream.Close();
    }

    ///Load playerstats data from file
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
    
    ///Save volume data to file
    public static void SaveVolume(float effect, float music)
    {
        float[] data = new float[2];
        data[0] = effect;
        data[1] = music;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(volumePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    ///Load volume data from file
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

    ///Write new record to highscores and save to file
    public static void SaveNewHighscore(int score, string name)
    {
        HighscoresMemory table = LoadHighscores();
        table.UpdateResults(score, name);
        SaveHighscoreObject(table);
    }

    ///Save highscores data to file
    private static void SaveHighscoreObject(HighscoresMemory data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/Highscores.fun";
        FileStream stream = new FileStream(highscoresPath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    ///Load highscores data from file
    public static HighscoresMemory LoadHighscores()
    {
        //string path = Application.persistentDataPath + "/Highscores.fun";
        HighscoresMemory data;
        if (File.Exists(highscoresPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(highscoresPath, FileMode.Open);
            stream.Position = 0;
            data = formatter.Deserialize(stream) as HighscoresMemory;
            stream.Close();
        }
        else
        {
            data = new HighscoresMemory();
            data.AddNoName();
            SaveHighscoreObject(data);
        }
        
        return data;
    }

}
