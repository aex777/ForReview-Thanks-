using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;
    public bool needRootate180;

    private void LateUpdate() {

        transform.LookAt(target.transform);
        if(needRootate180) {transform.Rotate(0,180,0);}


    }
}
