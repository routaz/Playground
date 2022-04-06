using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItemSpawner : MonoBehaviour
{
    //getters and setters
    public bool LootSpawnIsActive { get { return lootSpawnIsActive; } set { lootSpawnIsActive = value; } }

    [Header("Set loot item for rotation")]
    [SerializeField] GameObject _lootItem;
    [Header("Time before loot starts rotation")]
    [SerializeField] float _timeForLootBecomeActive = 5f;
    [Header("Time interval how oftern loot changes position")]
    [SerializeField] float _timeForLootToChangePosition = 10f;

    private List<GameObject> _lootSpawnpoints = new List<GameObject>();
    public bool lootSpawnIsActive = true;

    private GameObject _cachedLootItem;

    // Start is called before the first frame update
    void Start()
    {
        lootSpawnIsActive = true;
        HandleSpawnPoints();
        InvokeRepeating("SpawnLoot", _timeForLootBecomeActive, _timeForLootToChangePosition);
    }

    public void SpawnLoot()
    {
        int randomSpawnPoint = Random.Range(0, _lootSpawnpoints.Count);

        if (lootSpawnIsActive)
        {
            if (_cachedLootItem != null)
            {
                foreach (var lootSpawnPoint in GameObject.FindGameObjectsWithTag("LootSpawnPoint"))
                {
                    if (lootSpawnPoint.GetComponent<LootSpawnPoint>().isOccupied == true)
                    {
                        lootSpawnPoint.GetComponent<LootSpawnPoint>().HandleOccupationStatus();
                    }
                }
      
                _cachedLootItem.SetActive(false);
                _cachedLootItem.transform.position = _lootSpawnpoints[randomSpawnPoint].transform.position;
                _cachedLootItem.SetActive(true);
                //_cachedLootItem.GetComponent<LootItem>().ChangeToOriginalMaterial();
                _lootSpawnpoints[randomSpawnPoint].GetComponent<LootSpawnPoint>().HandleOccupationStatus();
                HandleSpawnPoints();
            }
            else if (_cachedLootItem == null)
            {
                _cachedLootItem = Instantiate(_lootItem, _lootSpawnpoints[randomSpawnPoint].transform.position, Quaternion.identity);
            }
            HandleSpawnPoints();
        }
        else
        {
            return;
        }
    }

    private void HandleSpawnPoints()
    {
        _lootSpawnpoints = new List<GameObject>();
        foreach (var lootSpawnPoint in GameObject.FindGameObjectsWithTag("LootSpawnPoint"))
        {
            if (lootSpawnPoint.GetComponent<LootSpawnPoint>().isOccupied == false)
            {
                AddToActiveSpawnpoints(lootSpawnPoint);
            }
        }
    }

    public void AddToActiveSpawnpoints(GameObject spawnPoint)
    {
        _lootSpawnpoints.Add(spawnPoint);
    }


    //THIS IS FOR BACKUP
    public void RemoveFromActiveSpawnpoints(GameObject spawnPoint)
    {
        _lootSpawnpoints.Remove(spawnPoint);
    }
}
