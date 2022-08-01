using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
public class FoodToTable : MonoBehaviour
{
    [SerializeField] private FoodStorage foodStorage;
    [SerializeField] private List<GameObject> _allTableFood;
    [SerializeField] private float _offsetBetweenFood;

    

    private void Start()
    {
        StartCoroutine(FoodToTableCorutine());
    }
    private IEnumerator FoodToTableCorutine()
    {
        while(true)
        {
            if (foodStorage)
            {
                if (foodStorage.GetLastFoodFromHands() != null)
                {
                    AddFoodToTable(foodStorage.GetLastFoodFromHands());
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    foodStorage.RemoveLastFoodFromHands();
                }

            }
            yield return new WaitForSeconds(0.2f);
        }    
    }
    public void AddFoodToTable(GameObject food)
    {
        food.transform.parent = null;
        food.transform.DOMove(new Vector3(_allTableFood[_allTableFood.Count - 1].transform.position.x, _allTableFood[_allTableFood.Count - 1].transform.position.y + 0.35f, _allTableFood[_allTableFood.Count - 1].transform.position.z), 0.2f);
        _allTableFood.Add(food);
    }





    public GameObject GetLastFoodOnTable()
    {
        if (_allTableFood.Count > 1)
        {
            return _allTableFood[_allTableFood.Count - 1];
        }
        else
        {
            return null;
        } 
        
    }
    public void RemoveLastFoodOnTable() 
    {
        _allTableFood.Remove(_allTableFood[_allTableFood.Count - 1]);
    }


    public float GetAllFoodOnTable()
    {
        return _allTableFood.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if(foodStorage==null)
        {
            if (other.GetComponentInParent<FoodStorage>()) { foodStorage = other.GetComponentInParent<FoodStorage>(); }
        }
                   
    }
    private void OnTriggerExit(Collider other)
    {
        foodStorage = null;
    }
}
