using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public struct Tile
{
    public float x, y, z;
    public int id;

    public Tile(float x, float y, float z, int id)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
}

public class GameManager : MonoBehaviour
{
    public AdditionalInfo[] PrefabsToSave;
    AdditionalInfo[] ScenePrefabs;
    public string path = @"D:\TestForSavingGame\MyLevel.bin";

    public void Save()
    {
        
        ScenePrefabs = GameObject.FindObjectsOfType<AdditionalInfo>();
        Tile[] t = new Tile[ScenePrefabs.Length];
        for(int i=0; i < t.Length; i++)
        {
            t[i] = new Tile(ScenePrefabs[i].transform.position.x, ScenePrefabs[i].transform.position.y, ScenePrefabs[i].transform.position.z, ScenePrefabs[i].id);
        }

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, t);
        stream.Close();
    }

    public void Load()
    {
        
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        var obj = (Tile[])formatter.Deserialize(stream);
        stream.Close();

        for(int i= 0; i < obj.Length; i++)
        {
            Instantiate(PrefabsToSave[obj[i].id], new Vector3(obj[i].x, obj[i].y, obj[i].z), Quaternion.identity);
        }
    }

    void Clear()
    {
        ScenePrefabs = GameObject.FindObjectsOfType<AdditionalInfo>();
        foreach(var i in ScenePrefabs)
        {
            Destroy(i.gameObject);
        }
    }
}
