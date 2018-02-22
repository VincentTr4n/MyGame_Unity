using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    //following target
    public Transform target;

    Vector3 v = Vector3.zero;
    public float Time = .15f;
    void FixedUpdate()
    {
        Vector3 tPosition = target.position;
        tPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, tPosition, ref v, Time);
    }
}
