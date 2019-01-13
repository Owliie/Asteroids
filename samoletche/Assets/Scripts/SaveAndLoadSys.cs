using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoadSys
{
    public static void SavePlayerRec()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/recs.save";
        FileStream file = new FileStream(path, FileMode.Create);
        SavedData data = new SavedData();
        formatter.Serialize(file, data);
        file.Close();
    }

    public static SavedData Load()
    {
        string path = Application.persistentDataPath + "/recs.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            SavedData data = formatter.Deserialize(file) as SavedData;
            file.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}

}
