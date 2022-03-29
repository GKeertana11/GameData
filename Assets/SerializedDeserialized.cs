using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SerializedDeserialized : MonoBehaviour
{
    public string filePath;
    // Start is called before the first frame update
    void Start()
    {

    

    }

    private void LoadData()
    {

        filePath = Application.persistentDataPath + "/Myfile.Keertana";
        FileStream file1 = new FileStream(filePath, FileMode.Open);
        BinaryReader bw = new BinaryReader(file1);
        Debug.Log(bw.ReadString());
        bw.Close();
        file1.Close();

    }

    private void SaveData()
    {
        filePath = Application.persistentDataPath + "/Myfile.Keertana";
        FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(file);
        bw.Write("Hello! I am Keertana Govte."); 
        bw.Write("I am Working at Purple Talk. I am a part of YesGnome.");
        bw.Write("21");
        bw.Close();
        file.Close();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadData();
        }
    }
}
