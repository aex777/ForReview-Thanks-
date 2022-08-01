using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<NavMeshAgent> _allAgents;
    [SerializeField] private GameObject _humanSpawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnHuman());
    }
    public IEnumerator SpawnHuman()
    {
        yield return new WaitForSeconds(_spawnCooldown);

        for (int i = 0; i < _allAgents.Count; i++)
        {
            if (_allAgents[i].gameObject.tag == "Hiden")
            {
                _allAgents[i].Warp(_humanSpawnPoint.transform.position);
                _allAgents[i].tag = "Player";


                break;
            }
        }
        StartCoroutine(SpawnHuman());
    }

}
