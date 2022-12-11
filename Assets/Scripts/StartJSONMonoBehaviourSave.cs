using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;
using UnityEditor;

public class StartJSONMonoBehaviourSave : MonoBehaviour
{
    [SerializeField] private SceneInitData _sceneInitData;

    private void Start()
    {
         //Средства Newtonsoft.Json       
         var jsonW = JsonConvert.SerializeObject(_sceneInitData);
         File.WriteAllText(Application.persistentDataPath + "/Save_Netonsoft.json", jsonW); // Сохраняем файл json
       
         var jsonRead = File.ReadAllText(Application.persistentDataPath + "/Save_Netonsoft.json"); // Читаем фаил json
         var Gjson = JsonConvert.DeserializeObject<SceneInitData>(jsonRead); // Десериализуем json

         var newScriptObj = ScriptableObject.CreateInstance<SceneInitData>(); // создаем шаблон класса-скрипта SceneInitData, можно опустить
         
         // заполняем поля шаблона  SceneInitData, можно слева добавить var и стереть строку выше
         newScriptObj = Gjson;

        //newScriptObj.MainCamera_s = Gjson.MainCamera_s;
        //newScriptObj.Gun_s = Gjson.Gun_s;
        //newScriptObj.TemplarKnightPrefab_s = Gjson.TemplarKnightPrefab_s;
        //newScriptObj.BettonWall_s = Gjson.BettonWall_s;
        //newScriptObj.Plane_s = Gjson.Plane_s;

        // Сохраняем новый фаил ScriptableObject по шаблону SceneInitData с сохраненными данными в фаиле /Save_Netonsoft.json
        AssetDatabase.CreateAsset(newScriptObj, "Assets/Resources/SceneInitDataNew.asset"); 


        //Средства Unity
        //var json = JsonUtility.ToJson(_sceneInitData);
        //File.WriteAllText(Application.persistentDataPath + "/Save_1.json", json);

        //var json = File.ReadAllText(Application.persistentDataPath + "/Save_1.json");
        //JsonUtility.FromJsonOverwrite(json, _sceneInitData);

        //Debug.Log(Application.persistentDataPath);

    }
}
