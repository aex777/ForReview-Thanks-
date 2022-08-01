using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitActivate : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    [SerializeField] private float waitTimeBeforeActivate;
    void Start()
    {
        Invoke("ActivateObject", waitTimeBeforeActivate);
    }

    public void ActivateObject()
    {
        _objectToActivate.SetActive(true);
    }
}
