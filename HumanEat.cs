using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HumanEat : MonoBehaviour
{
    [SerializeField] private HumanPay humanPay;
    [SerializeField] private HumanMove humanMove;
    [SerializeField] private FoodToTable foodToTable;
    [SerializeField] private float _countToEat;
    [SerializeField] private float _eatedFoodCount;
    [SerializeField] private float _eatingSpeed;
    [SerializeField] private GameObject _mouthPoint;
    [SerializeField] private GameObject _objectToEat;
    


    private void Start()
    {
        StartCoroutine(EatingFood());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            foodToTable = other.GetComponent<FoodToTable>();
            
        }
        if (other.gameObject.CompareTag("SetActive(False)"))
        {
            _eatedFoodCount = 0;
        }
    }
   

    public IEnumerator EatingFood()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            if (foodToTable && humanMove.CheckIsHumanSitting().isKinematic == true)
            {
                if (_eatedFoodCount != _countToEat)
                {
                    if (foodToTable.GetLastFoodOnTable() != null)
                    {
                        _objectToEat = foodToTable.GetLastFoodOnTable();
                        foodToTable.RemoveLastFoodOnTable();
                        _objectToEat.transform.DOMove(_mouthPoint.transform.position, 1f);
                        _eatedFoodCount++;
                        yield return new WaitForSeconds(1);
                        _objectToEat.SetActive(false);
                    }
                }
                if (_eatedFoodCount == _countToEat)
                {
                    yield return new WaitForSeconds(0.5f);
                    humanMove.ExitAfterEating();
                    humanPay.PayAfterEating();
                }
            }
        }
    }
    

}
