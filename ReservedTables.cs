using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReservedTables : MonoBehaviour
{
    [SerializeField] private bool _tableReserved;
    [SerializeField] private GameObject _sittingPoint;

   public GameObject ReserveTable()
   {
       _tableReserved = true;
        return _sittingPoint;

   }
    public void UnReserveTable()
    {
        _tableReserved = false;
    }
    public bool IsTableReserved()
    {
        return _tableReserved;
    }

    


}
