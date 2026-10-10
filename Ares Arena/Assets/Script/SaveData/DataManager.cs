using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    [HideInInspector] public SaveData Dscript;
    string filepath;
    string filename = "savedata.json";
    void Awake()
    {
        filepath = Application.persistentDataPath + "/" + filename;
        if(!File.Exists(filepath))
        {
            Save(Dscript);
        }
        Dscript = Load(filepath);
    }
    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        StreamWriter wr = new StreamWriter(filepath, false);
        wr.WriteLine(json);
        wr.Close();
    }
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);
        string json = rd.ReadToEnd();
        rd.Close();

        return JsonUtility.FromJson<SaveData>(json);
    }

    private void OnDestroy()
    {
        Save(Dscript);
    }
}
