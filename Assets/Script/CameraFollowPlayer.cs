using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{ public Transform target;
private Vector3 offset;
public float smoothSpeed = 0.05f;

private void Start() {
    offset = transform.position -target.position;

}

private void LateUpdate() {
    Vector3 newPosition = Vector3.Lerp(transform.position, 
    target.position + offset ,smoothSpeed);
    transform.position = newPosition;
}
}
