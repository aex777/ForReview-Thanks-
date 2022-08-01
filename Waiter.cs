using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private GameObject _cookingFoodPoint;
    [SerializeField] private List<GameObject> _allTablePoints;
    [SerializeField] private GameObject _currentTable;
    [SerializeField] private FoodStorage foodStorage;
    [SerializeField] private Animator animator;


    private void Start()
    {
        animator.SetBool("Run", true);
        MoveToCookingFoodPoint();
    }

    public void MoveToCookingFoodPoint()
    {
        _meshAgent.SetDestination(_cookingFoodPoint.transform.position);
    }

    public void MoveToRandomTable()
    {
        _currentTable = _allTablePoints[Random.Range(0, _allTablePoints.Count)];

        if(_currentTable.transform.parent.gameObject.activeSelf==true)
        {
            _meshAgent.SetDestination(_currentTable.transform.position);
        }
        else
        {
            MoveToRandomTable();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("WaiterCookingPoint"))
        {
            Debug.Log("Collide WaiterCookingPoint");
            animator.SetBool("Run", false);
            animator.SetBool("RunWithFood", false);
            animator.SetBool("Idle", true);

            if(foodStorage.ReturnFoodOnHandsCount() > foodStorage.ReturnCapacity())
            {
                Debug.Log("Move to random table");
                animator.SetBool("Idle", false);
                animator.SetBool("Run", false);
                animator.SetBool("RunWithFood", true);
                MoveToRandomTable();
            }
        }


        if (other.CompareTag("WaiterTablePoint"))
        {
            Debug.Log("Collide WaiterTablePoint");
            animator.SetBool("Run", false);
            animator.SetBool("RunWithFood", false);
            animator.SetBool("Idle", true);

            if (foodStorage.ReturnFoodOnHandsCount()==1)
            {
                Debug.Log("Move to cooking table");
                animator.SetBool("Idle", false);
                animator.SetBool("RunWithFood", false);
                animator.SetBool("Run", true);
                MoveToCookingFoodPoint();
            }
        }
    }

}
