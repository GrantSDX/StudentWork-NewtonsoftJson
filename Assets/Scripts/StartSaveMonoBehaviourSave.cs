using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;


public class StartSaveMonoBehaviourSave : MonoBehaviour
{
    public PlayerKnight PlayerKnight;
    [SerializeField] private Button ButtonSave;
    [SerializeField] private Button ButtonLoad;
    [SerializeField] private TextMeshProUGUI LabelLevel;
   
    [SerializeField] private SaveData SaveData = new SaveData();

  


    private void Update()
    {
        
        ButtonSave.onClick.AddListener(Save);
        ButtonLoad.onClick.AddListener(Load);
    }
    private void Save()
    {
        SaveData.Level = LabelLevel.text;
        SaveData.CoordX = PlayerKnight.transform.position.x;
        SaveData.CoordY = PlayerKnight.transform.position.y;
        SaveData.CoordZ = PlayerKnight.transform.position.z;

        var saveJson = JsonConvert.SerializeObject(SaveData);

        PlayerPrefs.SetString("Save", saveJson);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        var loadJson = PlayerPrefs.GetString("Save");
        var loadSaveData = JsonConvert.DeserializeObject<SaveData>(loadJson);
        
        PlayerKnight.GetComponent<Transform>().position = new Vector3(loadSaveData.CoordX, loadSaveData.CoordY, loadSaveData.CoordZ);
        LabelLevel.text = loadSaveData.Level;
    }



}

[Serializable]
public class SaveData
{
    public string Level;
    public float CoordX, CoordY, CoordZ;

    public SaveData()
    {
        Level = $"Level: {0f}";
        CoordX = CoordY = CoordZ = 0f;
    }
}
