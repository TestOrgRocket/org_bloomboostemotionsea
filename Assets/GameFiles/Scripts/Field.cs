using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject WaterPrefab, pickUpObjectPrefab;
    public int waterLayerWidth = 15;
    public int startCountOfLayers = 30;

    public GameObject playerToListen;

    float _currX;
    int _currLayer, _whichLayerToDelete;

    List<List<GameObject>> layers = new List<List<GameObject>>();

    private void OnEnable() {
        _currLayer = -10;
        for(int i = -10; i < startCountOfLayers; i++)
            SpawnLayers(i);
        _whichLayerToDelete = 0;
        _currX = playerToListen.transform.localPosition.x;
    }

    void SpawnLayers(int x){
        List<GameObject> temp_Layer = new List<GameObject>();
        GameObject water;
        for(int i = - waterLayerWidth; i < waterLayerWidth; i++){
            water = Instantiate(WaterPrefab, transform.position + new Vector3(x, 0, i), Quaternion.AngleAxis(90, new Vector3(1,0,0)), transform);
            water.name = "WaterFloor";
            temp_Layer.Add(water);
        }
        RandomSpawnPickUpObject(x);
        _currLayer += 1;
        layers.Add(temp_Layer);
    }

    void RandomSpawnPickUpObject(int x){
        int rndNum = Random.Range(0, 5);
        if(rndNum == 2){
            for(int i = 0; i < Random.Range(1,4); i++){
                float rndNum2 = Random.Range(-6f, 6.01f); 
                GameObject obj = Instantiate(pickUpObjectPrefab, transform);
                obj.transform.localPosition = new Vector3(x, 0, rndNum2);
                obj.tag = "pickup";
                obj.name = "PickUpColor";
            }
        }
    }

    private void Update() {
        if((int) playerToListen.transform.localPosition.x - _currX  >= 1f){
            foreach(GameObject layerItem in layers[_whichLayerToDelete]) Destroy(layerItem);

            _currX = (int) playerToListen.transform.localPosition.x;
            _whichLayerToDelete += 1;

            SpawnLayers(_currLayer);
        }
        
    }

    private void OnDisable() {
        for(int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).CompareTag("Player"))continue;
            Destroy(transform.GetChild(i).gameObject);
        }
        BaseManagement.Score = (int) Player.state;
    }

}
