using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class FoodToPlayer : MonoBehaviour
{
    [SerializeField] MakeFood makeFood;
    [SerializeField] private bool _playerOnTrigger;
    [SerializeField] private FoodStorage foodStorage;
    


    private void Start()
    {
        StartCoroutine(FoodToPlayerHands());
    }

    private void OnTriggerStay(Collider other)
    {
        if(foodStorage==null)
        {
            if (other.CompareTag("MainPlayer"))
            {
                _playerOnTrigger = true;
                foodStorage = other.GetComponentInParent<FoodStorage>();

            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        _playerOnTrigger = false;
        foodStorage = null;
    }

    public IEnumerator FoodToPlayerHands()
    {
        while(true)
        {
            if (_playerOnTrigger == true)
            {
                if (makeFood.CheckReadyFoodCount() > 1   && foodStorage.ReturnFoodOnHandsCount() <= foodStorage.ReturnCapacity())
                {
                    foodStorage.AddFoodToHands(makeFood.GetLastFoodFromKitchen());
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    makeFood.RemoveLastFoodFromKitchen();
                }

            }

            yield return new WaitForSeconds(0.2f);
            
        }
        
    }
    
   
     
    

}
