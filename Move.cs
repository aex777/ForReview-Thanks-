using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Move : MonoBehaviour
{
    [SerializeField] private FoodStorage foodStorage;
    [SerializeField] private SetActiveChar _setActiveChar;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _gameCamera;
    [Header ("Set in code")]
    [SerializeField] private bool _canMove;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _activeChatacter;
    [SerializeField] private bool _isMoving;

   
    private void Start()
    {
        _activeChatacter = _setActiveChar.ActiveCharacter;
        _animator = _activeChatacter.GetComponent<Animator>();
        _rb = _activeChatacter.GetComponent<Rigidbody>();
        
    }
    
   
    

    private void FixedUpdate()
    {
        Moving();
        AnimationState();
    }

    public void AnimationState()
    {
        
        if (foodStorage.CheckHasFoodOnHands()==false &&  (_joystick.Horizontal != 0 || _joystick.Vertical != 0)) { _animator.SetBool("Idle", false); _animator.SetBool("RunWithFood", false); _animator.SetBool("Run", true); }
        if (foodStorage.CheckHasFoodOnHands() == true && (_joystick.Horizontal != 0 || _joystick.Vertical != 0)) { _animator.SetBool("Idle", false); _animator.SetBool("Run", false); _animator.SetBool("RunWithFood", true);  }
        if (_joystick.Horizontal == 0 && _joystick.Vertical == 0) { _animator.SetBool("RunWithFood", false); _animator.SetBool("Run", false); _animator.SetBool("Idle", true); }


    }
    public void Moving()
    {
        if (_canMove == true)
        {
          _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rb.velocity.y , _joystick.Vertical * _moveSpeed);

           if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
           {
               _rb.transform.rotation = Quaternion.LookRotation(_rb.velocity);
                _isMoving = true;
           }
           else
           {
               _isMoving = false;
           }
               
        }
    }
    public bool CheckIsCharacterMoving()
    {
        return _isMoving;
    }
    
    public void UpgradeMainCharacterMoveSpeed(float  moveSpeed)
    {
        _moveSpeed += moveSpeed;
    }
    
  
   
}
