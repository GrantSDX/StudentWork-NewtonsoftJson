using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "Init Data/Scenes Init data", fileName = "Scene Init data", order = 0)]
public class SceneInitData : ScriptableObject
{

    [JsonProperty("Camera-Main")] public string MainCamera_s;

    [JsonProperty("Pushka_Gun")] public string Gun_s;

    [JsonProperty("Knight_1")] public string TemplarKnightPrefab_s;

    [JsonProperty("Beton_D")] public string BettonWall_s;

    [JsonProperty("Pol_ka")] public string Plane_s;


}
