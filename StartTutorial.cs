using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartTutorial : MonoBehaviour
{
    
    [SerializeField] private Move _move;
    public UIManager uiManager;
    public GameObject handTutorial;
    public GameObject hand;
    public Vector3 pointA;
    public Vector3 pointB;
    public float moveSpeed;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //_move.CanMove = true;
            handTutorial.gameObject.SetActive(false);
        }
    }
    //private void Start()
    //{
    //    StartCoroutine("HandMove");
    //}
    // public IEnumerator HandMove()
    // {

    //     hand.transform.DOLocalMove(pointB, moveSpeed).SetEase(Ease.Linear);
    //     yield return new WaitForSeconds(moveSpeed);
    //     hand.transform.DOLocalMove(pointA, moveSpeed).SetEase(Ease.Linear);
    //     yield return new WaitForSeconds(moveSpeed);
    //     StartCoroutine("handMove");
    // }
  
    
}
