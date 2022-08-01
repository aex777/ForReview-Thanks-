using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class BuyingTrigger : MonoBehaviour
{
    
    [SerializeField] Move move;
    [SerializeField] private MoneyManager moneyManager;

    [SerializeField] private GameObject _objectCanvas;
    [SerializeField] private TextMeshProUGUI _objectPriceTMP;
    [SerializeField] private float _objectStartPrice;
    [SerializeField] private float _objectCurrentPrice;
    [SerializeField] private Image _priceFill;

    
    [SerializeField] private GameObject _buyingObject;
    [SerializeField] private GameObject _nextObjectToBuy;
    [SerializeField] private float _buyingObjectFinishScale;
    [SerializeField] private bool _playerOnTrigger;


    private void Start()
    {
        _objectCurrentPrice = _objectStartPrice;
        _objectPriceTMP.text = $"{"$ " + _objectCurrentPrice }";
        StartCoroutine(BuyingCorutine());
    }
    public IEnumerator BuyingCorutine()
    {
        while(true)
        {
            if (_playerOnTrigger)
            {
                if (moneyManager.CheckMoneyCount() >= _objectStartPrice / 10)
                {
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    moneyManager.SpendMoney(_objectStartPrice / 10);
                   _objectCurrentPrice -= _objectStartPrice / 10;
                    _objectPriceTMP.text = $"{"$ " + _objectCurrentPrice }";
                    _priceFill.fillAmount += 0.1f;
                }
                if (_objectCurrentPrice == 0)
                {
                    _objectCanvas.SetActive(false);
                    _buyingObject.SetActive(true);
                    _buyingObject.transform.DOScale(_buyingObjectFinishScale, 0.5f);
                    
                    yield return new WaitForSeconds(1f);
                    _nextObjectToBuy.SetActive(true);
                    this.gameObject.SetActive(false);
                    break;
                }

            }

            yield return new WaitForSeconds(0.1f);
        }
        

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainPlayer") && move.CheckIsCharacterMoving()==false)
        {
            _playerOnTrigger = true;
        }
        else
        {
            _playerOnTrigger = false;
        }
    }
   
}
