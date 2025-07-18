using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Material[] materials;
    float[] value = {-3f, -1f, 0.5f, 2f, 3f, -9999999f};

    int _thisInt;
    GameObject _player;

    private void OnEnable() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thisInt = Random.Range(0, materials.Length);
        GetComponent<MeshRenderer>().material = materials[_thisInt];
    }

    public float changeDependingOnMaterial(){
        // for(int i = 0; i< materials.Length; i++){
        //     if(materials[i].name == GetComponent<MeshRenderer>().material.name)
        //         return value[i];
        // }
        // return 0;
        return value[_thisInt];
    }

    private void Update() {
        if(_player.transform.position.x - transform.position.x > 5f){
            Destroy(gameObject);
        }
    }
}
