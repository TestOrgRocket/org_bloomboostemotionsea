using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    public Vector3 offsetPosition;
    public Vector3 offsetLookPoint;

    private void OnEnable() {
        player.transform.localPosition = Vector3.zero;
    }
    private void Update() {
        if(player == null) return;
        CameraFollowPlayer();
        CameraLookAtPlayer();
    }
    void CameraFollowPlayer(){
        camera.transform.localPosition = new Vector3(player.transform.localPosition.x + offsetPosition.x, player.transform.localPosition.y + offsetPosition.y, player.transform.localPosition.z);
    }
    void CameraLookAtPlayer(){
        Vector3 targetPosition = player.transform.localPosition + offsetLookPoint;
        camera.transform.LookAt(targetPosition + Vector3.up);
    }

}
