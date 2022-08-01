using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnim : MonoBehaviour
{
    [SerializeField] private GameObject _thisParentObject;
    [SerializeField] private GameObject _nextToActivateObject;
    [SerializeField] private bool _playAnimation;
    [SerializeField] private float _startScaleValue;
    [SerializeField] private float _endScaleValue;
    private void Start()
    {
        if (_playAnimation == true) StartCoroutine(AnimationCorutine());
    }
    public IEnumerator AnimationCorutine()
    {
        while(true)
        {
            this.gameObject.transform.DOScale(_startScaleValue, 0.5f);
            yield return new WaitForSeconds(0.5f);
            this.gameObject.transform.DOScale(_endScaleValue, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MainPlayer"))
        {
            _thisParentObject.gameObject.SetActive(false);
            if (_nextToActivateObject) {  _nextToActivateObject.SetActive(true); }
        }
    }
}
