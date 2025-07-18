using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f, horizontalSpeed = 3f;
    public Material Zero,Half,One;
    public static float state = 0f;
    Rigidbody _rb;
    Vector3 _firstPos, _secondPos;
    private void OnEnable() {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(1, 0 ,0) * moveSpeed;
        state = 0f;
        GetComponent<MeshRenderer>().material = Zero;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("pickup")){
            _rb.velocity = new Vector3(1, 0 ,0) * moveSpeed;
            float value = other.gameObject.GetComponent<PickUpObject>().changeDependingOnMaterial();
            if(value == -9999999f){
                BaseManagement.Score = (int) state;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseManagement>().OpenGameEnd();
                return;
            }
            state += value;
            CheckState();
            Destroy(other.gameObject);
        }
    }

    void CheckState(){
        if(state >= 0f && state < 20f)
            GetComponent<MeshRenderer>().material = Zero;
        else if(state >= 20f && state < 50f)
            GetComponent<MeshRenderer>().material = Half;
        else if(state >= 50f)
            GetComponent<MeshRenderer>().material = One;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            _firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0)){
            _secondPos = Input.mousePosition;
            // float distance = Vector3.Distance(_firstPos, _secondPos);
            float distance = _secondPos.x < _firstPos.x ? 1f : -1f;
            if(distance >= 0){
                _rb.velocity = new Vector3(0, 0 ,1) * horizontalSpeed + new Vector3(1, 0, 0) * moveSpeed;
            } else {
                _rb.velocity = new Vector3(0, 0 ,-1) * horizontalSpeed + new Vector3(1, 0, 0) * moveSpeed;
            }
        } 
        else if (Input.GetMouseButtonUp(0)){
            _rb.velocity = new Vector3(1, 0 ,0) * moveSpeed;
        }
        if (transform.position.z < -4f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4f);
        }
        else if (transform.position.z > 4f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4f);
        }

        if(state < -10f){
            BaseManagement.Score = (int) state;
            Debug.Log("gg");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseManagement>().OpenGameEnd();
        }
    }
}
