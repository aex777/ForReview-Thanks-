using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveChar : MonoBehaviour
{
    [SerializeField] private List<GameObject> _characters;
    public GameObject ActiveCharacter { get; private set; }

    
    private void Awake()
    {
        SetActiveCharacter();
    }
    private void SetActiveCharacter()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            if (_characters[i].activeSelf)
            {
                ActiveCharacter = _characters[i];
                break;
            }
        }
    }
}
