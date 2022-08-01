using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodStorage : MonoBehaviour
{
    [SerializeField] private GameObject _maxFoodOnHandsText;
    [SerializeField] private List<GameObject> _foodOnHands;
    [SerializeField] private GameObject _foodParent;
    [SerializeField] private bool _hasFoodOnHands;
    [SerializeField] private float _capacity;

    public void AddFoodToHands(GameObject foodObject)

    {
        foodObject.transform.DOLocalMove(new Vector3(_foodOnHands[_foodOnHands.Count - 1].transform.localPosition.x, _foodOnHands[_foodOnHands.Count - 1].transform.localPosition.y + 0.5f, _foodOnHands[_foodOnHands.Count - 1].transform.localPosition.z), 0.2f);
        _foodOnHands.Add(foodObject);
        foodObject.transform.parent = _foodParent.gameObject.transform;

    }

    public GameObject GetLastFoodFromHands()
    {
        if (_foodOnHands.Count > 1) { return _foodOnHands[_foodOnHands.Count - 1]; }
        else { return null; }

    }
    public void RemoveLastFoodFromHands()
    {
        _foodOnHands.Remove(_foodOnHands[_foodOnHands.Count - 1]);
    }
    public bool CheckHasFoodOnHands()
    {
        if (_foodOnHands.Count > 1) { _hasFoodOnHands = true; }
        if (_foodOnHands.Count <= 1) { _hasFoodOnHands = false;  }

        return _hasFoodOnHands;
    }

    public float ReturnCapacity()
    {
        return _capacity;
    }
    public float ReturnFoodOnHandsCount()
    {
        return _foodOnHands.Count;
    }

    public void UpgradeCapacity(float capacity)
    {
        _capacity += capacity;
    }

    private void FixedUpdate()
    {
        if (_foodOnHands.Count > _capacity)
        {
            _maxFoodOnHandsText.SetActive(true);
        }
        else
        {
            _maxFoodOnHandsText.SetActive(false);

        }
    }
}
