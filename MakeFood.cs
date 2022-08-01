using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class MakeFood : MonoBehaviour
{
    [SerializeField] private float _timeCooking;
    [SerializeField] private List<GameObject> _allFood;
    [SerializeField] private List<GameObject> _cookedFood;
    [SerializeField] private bool _isHumanOnCookingTrigger;
    [SerializeField] private GameObject _allBurgersParent;
    [SerializeField] private float _offsetBetweenFood;

    [SerializeField] private float _timer;
    [SerializeField] private Image _reuseImage; //Картинка бургера на откате UI
    [SerializeField] private Image _reuseImage2; //Фон для картинки



    private void Start()
    {
         StartCoroutine(CoockingFood());
       
    }
    public IEnumerator CoockingFood()
    {
        while(true)
        {
            if (_isHumanOnCookingTrigger)
            {
                _reuseImage.enabled = true;
                _reuseImage2.enabled = true;
                _timer = 0;

                for (int i = 0; i < _allFood.Count - 1; i++)
                {
                    if (_allFood[i].activeSelf == false)
                    {
                        _allFood[i].SetActive(true);
                        _allFood[i].transform.parent = _allBurgersParent.transform;
                        _allFood[i].transform.localPosition = new Vector3(_cookedFood[_cookedFood.Count - 1].transform.localPosition.x, _cookedFood[_cookedFood.Count - 1].transform.localPosition.y + _offsetBetweenFood, _cookedFood[_cookedFood.Count - 1].transform.localPosition.z);
                        _cookedFood.Add(_allFood[i]);



                        yield return new WaitForSeconds(_timeCooking);
                        break;
                    }
                }
            }
            if(_isHumanOnCookingTrigger==false)
            {
                _reuseImage.enabled = false;
                _reuseImage2.enabled = false;
            }
            
            
                
            yield return new WaitForSeconds(0.2f);
            
        }
    }
    private void OnTriggerStay(Collider other) { _isHumanOnCookingTrigger = true; }
    private void OnTriggerExit(Collider other) { _isHumanOnCookingTrigger = false; }

    
    public GameObject GetLastFoodFromKitchen()
    {
      return _cookedFood[_cookedFood.Count - 1];
    }
    public void RemoveLastFoodFromKitchen()
    {
        _cookedFood.Remove(_cookedFood[_cookedFood.Count - 1]);
    }

    public int CheckReadyFoodCount()
    {
        return _cookedFood.Count;
    }


    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
         _reuseImage.fillAmount = _timer / _timeCooking; 
         _reuseImage2.fillAmount = _timer / _timeCooking; 

    }

    public void UpgradeCookingSpeed(float timeCooking)
    {
        _timeCooking -= timeCooking;
    }
}
