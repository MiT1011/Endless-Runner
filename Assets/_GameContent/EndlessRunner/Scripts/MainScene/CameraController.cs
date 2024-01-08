using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 Offset;

    private void Start() {
        Offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, Offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10*Time.deltaTime);
    }
}
