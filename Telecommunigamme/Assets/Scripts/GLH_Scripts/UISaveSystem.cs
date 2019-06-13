using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class UISaveSystem 
{
    

    public static void SaveUI(TimeLine timeline, ObjectManager objects, QuestManager quests)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/UI.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        UIData data = new UIData(timeline, objects, quests);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static UIData LoadUI()
    {
        string path = Application.persistentDataPath + "/UI.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                UIData data = formatter.Deserialize(stream) as UIData;
                stream.Close();
                return data;
            }

        }
        else
        {
            Debug.LogError("Save not found");
            return null;
        }
    }
}
