using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _currentLevel;

    [SerializeField] private GameObject _winPopUp;
    [SerializeField] private GameObject _loosePopUp;
  
    [SerializeField] private GameObject _graphy;
    [SerializeField] private GameObject _debugConsole;


    public void NextLevel() { SceneManager.LoadScene(++_currentLevel); }
    public void Restart() { SceneManager.LoadScene(_currentLevel); }
    public void FpsOn() { _graphy.SetActive(true); _debugConsole.SetActive(true); }
    public void FpsOff() { _graphy.SetActive(false); _debugConsole.SetActive(false); }
    
    
    private void Start()
    {
        
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
   
   


}
