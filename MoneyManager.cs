using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMoneyCountTMP; 
    [SerializeField] private float _totalMoneylCount;



    private void FixedUpdate()
    {
        _totalMoneyCountTMP.text = GetSuffixValue(_totalMoneylCount);
    }

    public void EarnMoney(float earningCount)
    {
        _totalMoneylCount += earningCount;
    }

    public void SpendMoney(float spendCount)
    {
        _totalMoneylCount -= spendCount;
       
    }

    public float CheckMoneyCount()
    {
        return _totalMoneylCount;
    }
    string GetSuffixValue(float totalMoneyCount)
    {
        int zero = 0;

        while (totalMoneyCount >= 1000)
        {
            ++zero;

            totalMoneyCount /= 1000;
        }

        string suffix = string.Empty;

        switch (zero)
        {
            case 1: suffix = "K"; break;
            case 2: suffix = "M"; break;
            case 3: suffix = "B"; break;
            case 4: suffix = "T"; break;
            case 5: suffix = "Qd"; break;
            case 6: suffix = "Qn"; break;
            case 7: suffix = "Sx"; break;
            case 8: suffix = "Sp"; break;
            case 9: suffix = "Oc"; break;
        }

        return $"{"$" + totalMoneyCount:0.##}{suffix}";
    }
    
}
