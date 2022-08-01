using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private List<GameObject> _wayPoints;
    [SerializeField] private GameObject _wayPointTarget;
    [SerializeField] private GameObject _disablingTrigger;
    [SerializeField] private GameObject _hiddenWayPoint;

    [SerializeField] private List<ReservedTables> _tables;
    [SerializeField] private GameObject _reservedTable;
    [SerializeField] private bool _hasEated;
    [SerializeField] private bool _goingToTable;
    
    
    

    private void Start()
    {
        animator.SetBool("Walk", true);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint") && _goingToTable == false)
        {
            for (int i = 0; i < _wayPoints.Count; i++) //Устанавливаем следующий чекпоинт
            {
                if (other.gameObject == _wayPoints[i])
                {
                    _wayPointTarget = _wayPoints[i + 1];
                    break;
                }
            }


            if (_hasEated==false)
            {
                CheckReservedTables(); //Проверка столов + бронь + Таргет если свободно
            }

            _meshAgent.SetDestination(_wayPointTarget.transform.position);
        }

        if (other.gameObject.CompareTag("Bench") && _hasEated == false)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Sitdown", true);
            _rb.isKinematic = true;
        }

        if (other.gameObject.CompareTag("SetActive(False)"))
        {
            _hasEated = false;
            _goingToTable = false;
            _meshAgent.Warp(_hiddenWayPoint.transform.position);
            this.gameObject.tag = "Hiden";
            

        }
    }
    public void CheckReservedTables()
    {
        for (int i = 0; i < _tables.Count; i++)
        {
            if (_tables[i].isActiveAndEnabled && _tables[i].IsTableReserved() == false)
            {
                _reservedTable = _tables[i].gameObject;
                _wayPointTarget = _tables[i].ReserveTable();
                _goingToTable = true;
                break;
            }
        }
    }
    public void ExitAfterEating()
    {
        _reservedTable.GetComponent<ReservedTables>().UnReserveTable();
        _hasEated = true;
        _rb.isKinematic = false;
        _meshAgent.SetDestination(_disablingTrigger.transform.position);
        animator.SetBool("Sitdown", false);
        animator.SetBool("Walk", true);
    }
    public Rigidbody CheckIsHumanSitting() //Проверяем сидит ли через rb.isKinematic 
    {
        return _rb;
    }
    
}
