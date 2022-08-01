using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using UnityEngine.UI;
public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private GameObject _upgradeWindow;

    [SerializeField] private GameObject _mainCharacter;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject joystickGameObject;
    [SerializeField] private float _timer;


    [SerializeField] private Move _mainCharacterMoveScript;//Апгрейдим скорость бега
    

    [SerializeField] private FoodStorage _foodStorage;//Апгрейдим вместимость в руках
    
    [SerializeField] private MakeFood kitchenMakeFood1;//Апгрейдим скорость приготовления пищи
    [SerializeField] private MakeFood kitchenMakeFood2;
    [SerializeField] private MakeFood kitchenMakeFood3;

    
    
    [SerializeField] private float _upgradeMoveSpeedPrice;
    [SerializeField] private float _upgradeCapacityPrice;
    [SerializeField] private float _upgradeKitchenCookingSpeedPrice;
    
    
    [SerializeField] private TextMeshProUGUI _upgradeMoveSpeedPriceTMP;
    [SerializeField] private TextMeshProUGUI _upgradeCapacityPriceTMP;
    [SerializeField] private TextMeshProUGUI _upgradeKitchenCookingSpeedPriceTMP;

    [SerializeField] private GameObject _notEnoughMoneyTMP;

    [SerializeField] private Image _moveSpeedSlider;
    [SerializeField] private Image _kitchenCookingSpeedSlider;
    [SerializeField] private Image _capacitySlider;



    private void Start()
    {
        if (_upgradeMoveSpeedPriceTMP != null)           { _upgradeMoveSpeedPriceTMP.text = $"{"$" + _upgradeMoveSpeedPrice}"; }
        if (_upgradeCapacityPriceTMP != null)            { _upgradeCapacityPriceTMP.text = $"{"$" + _upgradeCapacityPrice}"; }
        if (_upgradeKitchenCookingSpeedPriceTMP != null) { _upgradeKitchenCookingSpeedPriceTMP.text = $"{"$" + _upgradeKitchenCookingSpeedPrice}"; }
    }
    private void OnTriggerStay(Collider other)  
    {
        if(other.gameObject==_mainCharacter.gameObject && joystick.Horizontal==0 && joystick.Vertical==0 && _timer<0)
        {
            _upgradeWindow.SetActive(true);
            joystick.enabled = false;
            joystickGameObject.SetActive(false);

        }
    }
    
    public void CloseUpgradeWindow()
    {
        _upgradeWindow.SetActive(false);
        joystick.enabled = true;
        joystickGameObject.SetActive(true);
        _timer = 2f;
    }

    private void FixedUpdate()
    {
        _timer -= Time.deltaTime;
    }

    public void UpgradeMoveSpeed()
    {
        if (_mainCharacterMoveScript) 
        {
            if(moneyManager.CheckMoneyCount() >= _upgradeMoveSpeedPrice)
            {
                if(_moveSpeedSlider.fillAmount < 0.96f) //Ограничение апгрейда
                {
                    _moveSpeedSlider.fillAmount += 0.16f;
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    moneyManager.SpendMoney(_upgradeMoveSpeedPrice);
                    _mainCharacterMoveScript.UpgradeMainCharacterMoveSpeed(0.5f);
                }
                
            }
            else
            {
                StartCoroutine(NotEnoughMoneyTextCorutine());
            }
        }
    }
    public void UpgradeMoveSpeedRewarded()
    {
        if (_mainCharacterMoveScript)
        {
            if (_moveSpeedSlider.fillAmount < 0.96f) //Ограничение апгрейда
            {
                _moveSpeedSlider.fillAmount += 0.16f;
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                _mainCharacterMoveScript.UpgradeMainCharacterMoveSpeed(0.5f);
            }
        }
    }



    public void UpgradeCapacity()
    {
        if (moneyManager.CheckMoneyCount() >= _upgradeCapacityPrice)
        {
            if(_capacitySlider.fillAmount < 0.96f)
            {
                _capacitySlider.fillAmount += 0.16f;
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                moneyManager.SpendMoney(_upgradeCapacityPrice);
                _foodStorage.UpgradeCapacity(2f);
            }
            
        }
        else
        {
            StartCoroutine(NotEnoughMoneyTextCorutine());
        }
    }
    public void UpgradeCapacityRewarded()
    {
        if (_mainCharacterMoveScript)
        {
            if (_capacitySlider.fillAmount < 0.96f) //Ограничение апгрейда
            {
                _capacitySlider.fillAmount += 0.16f;
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                _foodStorage.UpgradeCapacity(2f);
            }
        }
    }



    public void UpgradeCookingSpeeed()
    {
        if (moneyManager.CheckMoneyCount() >= _upgradeKitchenCookingSpeedPrice)
        {
            if(_kitchenCookingSpeedSlider.fillAmount < 0.96f)
            {
                _kitchenCookingSpeedSlider.fillAmount += 0.16f;
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                moneyManager.SpendMoney(_upgradeKitchenCookingSpeedPrice);
                kitchenMakeFood1.UpgradeCookingSpeed(0.3f);
                kitchenMakeFood2.UpgradeCookingSpeed(0.3f);
                kitchenMakeFood3.UpgradeCookingSpeed(0.3f);
            }
            
        }
        else
        {
            StartCoroutine(NotEnoughMoneyTextCorutine());
        }
    }
    public void UpgradeCookingSpeeedRewarded()
    {
        if (_mainCharacterMoveScript)
        {
            if (_kitchenCookingSpeedSlider.fillAmount < 0.96f) //Ограничение апгрейда
            {
                _kitchenCookingSpeedSlider.fillAmount += 0.16f;
                MMVibrationManager.Haptic(HapticTypes.LightImpact);
                kitchenMakeFood1.UpgradeCookingSpeed(0.3f);
                kitchenMakeFood2.UpgradeCookingSpeed(0.3f);
                kitchenMakeFood3.UpgradeCookingSpeed(0.3f);
            }   
        }       
    }

    public IEnumerator NotEnoughMoneyTextCorutine()
    {
        _notEnoughMoneyTMP.transform.DOScale(2.5f, 1f);
        yield return new WaitForSeconds(1);
        _notEnoughMoneyTMP.transform.DOScale(0f, 1f);
    }

    
}
