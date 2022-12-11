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
         //�������� Newtonsoft.Json       
         var jsonW = JsonConvert.SerializeObject(_sceneInitData);
         File.WriteAllText(Application.persistentDataPath + "/Save_Netonsoft.json", jsonW); // ��������� ���� json
       
         var jsonRead = File.ReadAllText(Application.persistentDataPath + "/Save_Netonsoft.json"); // ������ ���� json
         var Gjson = JsonConvert.DeserializeObject<SceneInitData>(jsonRead); // ������������� json

         var newScriptObj = ScriptableObject.CreateInstance<SceneInitData>(); // ������� ������ ������-������� SceneInitData, ����� ��������
         
         // ��������� ���� �������  SceneInitData, ����� ����� �������� var � ������� ������ ����
         newScriptObj = Gjson;

        //newScriptObj.MainCamera_s = Gjson.MainCamera_s;
        //newScriptObj.Gun_s = Gjson.Gun_s;
        //newScriptObj.TemplarKnightPrefab_s = Gjson.TemplarKnightPrefab_s;
        //newScriptObj.BettonWall_s = Gjson.BettonWall_s;
        //newScriptObj.Plane_s = Gjson.Plane_s;

        // ��������� ����� ���� ScriptableObject �� ������� SceneInitData � ������������ ������� � ����� /Save_Netonsoft.json
        AssetDatabase.CreateAsset(newScriptObj, "Assets/Resources/SceneInitDataNew.asset"); 


        //�������� Unity
        //var json = JsonUtility.ToJson(_sceneInitData);
        //File.WriteAllText(Application.persistentDataPath + "/Save_1.json", json);

        //var json = File.ReadAllText(Application.persistentDataPath + "/Save_1.json");
        //JsonUtility.FromJsonOverwrite(json, _sceneInitData);

        //Debug.Log(Application.persistentDataPath);

    }
}
