using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _timeFollow;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject ObjectToFollow;

    void LateUpdate()
    {
      transform.position = Vector3.Lerp(this.transform.position, new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y+offset.y, ObjectToFollow.transform.position.z + offset.z) , _timeFollow );
    }
  
}
