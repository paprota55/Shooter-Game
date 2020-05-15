using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSave
{
    public static void SaveResult(string name, float result)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, name+" " + result);
        stream.Close();
    }
}
