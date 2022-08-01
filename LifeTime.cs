using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("LifeTimeCorutine");
    }

    public IEnumerator LifeTimeCorutine()
    {
        yield return new WaitForSeconds(2.5f);
        this.gameObject.SetActive(false);
    }
}
