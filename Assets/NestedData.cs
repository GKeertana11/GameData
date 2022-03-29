using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class NestedData : MonoBehaviour
{
    private string pName="Keertana";
    private int score=500;
    private int maxScore=2000;
    private int health=1;
    private int maxHealth = 5;
    public string filePath;
    
    private static ToSerializeData instance;

   [System.Serializable]
    public  class ToSerializeData
    {
        public string name;
        public int score;
        public int health;
        public int maxHealth;
         
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ToSaveData();
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.L))
        {
            ToLoadData();
        }    
    }

    public void ToSaveData()
    {
        BinaryFormatter binary = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/Myfile2.keeru";
        FileStream file = new FileStream(filePath,FileMode.OpenOrCreate);
    BinaryWriter br = new BinaryWriter(file);
        ToSerializeData data = new ToSerializeData();
        data.name = pName;
        data.score = score;
        data.health = health;
        data.maxHealth = maxHealth;
        binary.Serialize(file, data);
        file.Close();

       
    }
    public void ToLoadData()
    {
        
        filePath = Application.persistentDataPath + "/Myfile2.keeru";
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = new FileStream(filePath,FileMode.Open);
        ToSerializeData data = binary.Deserialize(file) as ToSerializeData;
         Debug.Log(data.name);
         Debug.Log(data.score);
         Debug.Log(data.health);
         Debug.Log(maxHealth);
       // Debug.Log(data);
        string mydata=data.ToString();


        file.Close();


    }

}

