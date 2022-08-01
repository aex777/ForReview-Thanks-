using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;

public class TableMoney : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _earnedDollarPrefabs;
    [SerializeField] private float _eachBurgerRevenue;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private GameObject _mainCharacter;
    [SerializeField] private GameObject _mainCharacterDollarFinishPoint;
    [SerializeField] private bool _mainCharacterOnTriger;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== _mainCharacter)
        {
            if(_earnedDollarPrefabs.Count>1) //Поднятие денег лежащих на полу
            {
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                
                for (int i = 1; i < _earnedDollarPrefabs.Count; i++)
                {
                    _earnedDollarPrefabs[i].transform.parent = _mainCharacter.transform;
                    _earnedDollarPrefabs[i].transform.DOLocalJump(_mainCharacterDollarFinishPoint.transform.localPosition, 3, 1, 1);
                    _earnedDollarPrefabs[i].transform.DOScale(2f, 1);
                    Invoke("offAllMoney", 0.75f);
                    moneyManager.EarnMoney(_eachBurgerRevenue);
                }
            }
            
        }
    }
    public void offAllMoney()
    {
        for (int i = 1; i < _earnedDollarPrefabs.Count; i++)
        {
            _earnedDollarPrefabs[i].SetActive(false);
            _earnedDollarPrefabs.Remove(_earnedDollarPrefabs[i]);
        }
    }
    
    public GameObject ReturnLastStackedDollar()
    {
        return _earnedDollarPrefabs[_earnedDollarPrefabs.Count - 1];
    }
    public void AddToEarnedDollarPrefabs(GameObject dollarPrefab)
    {
        _earnedDollarPrefabs.Add(dollarPrefab);
    }
}
