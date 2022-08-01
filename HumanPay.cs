using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HumanPay : MonoBehaviour
{
    [SerializeField] TableMoney tableMoney;
    [SerializeField] private List<GameObject> _allHumanDollars;
    [SerializeField] private GameObject _currentPayingDollar;
    [SerializeField] private GameObject _payDollarEndPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            tableMoney = other.GetComponentInChildren<TableMoney>();
        }
    }


    public void PayAfterEating()
    {
        ChangeDisabledDollarToPay();
        _payDollarEndPoint = tableMoney.ReturnLastStackedDollar();
        _currentPayingDollar.SetActive(true);
        _currentPayingDollar.transform.parent = this.gameObject.transform;
        _currentPayingDollar.transform.DOScale(2f, 0.1f); //«адаем стандартный размер 2.0 (при сборе мы тоже устанавливаем 2.0 но оно оменьшаетс€ из за парента )
        _currentPayingDollar.transform.localPosition = Vector3.zero;
        _currentPayingDollar.transform.parent = null;
        _currentPayingDollar.transform.rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        _currentPayingDollar.transform.DOJump(new Vector3(_payDollarEndPoint.transform.position.x, _payDollarEndPoint.transform.position.y + 0.15f, _payDollarEndPoint.transform.position.z),1,1,1);
        tableMoney.AddToEarnedDollarPrefabs(_currentPayingDollar);
        
    }
    public void ChangeDisabledDollarToPay()
    {
        for (int i = 0; i < _allHumanDollars.Count-1; i++)
        {
            if(_allHumanDollars[i].activeSelf==false)
            {
                _currentPayingDollar = _allHumanDollars[i];
                break;
            }
        }
    }
}
