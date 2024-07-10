using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    public List<string> scripts = new List<string>();

    /*public void OnEnable()
    {
        LoadScriptable();
    }

    public void OnDisable()
    {
        SaveScriptable();
    }*/

    public void ResetScriptable()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            }
        }
    }

    public void SaveScriptable()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var Json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, Json);
            file.Close();
        }
    }

    public void LoadScriptable()
    {
        for(int i = 0; i < objects.Count ; i++) {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }
}
