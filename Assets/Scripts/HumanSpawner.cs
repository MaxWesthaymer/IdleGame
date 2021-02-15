using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject humanPrefab;
    private List<HumanController> _humans;
    private float _spawnRate = 2f;
    private float _cooldown;
    void Start()
    {
        _humans = new List<HumanController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown <= 0)
        {
            SpawnHuman();
            _cooldown = _spawnRate;
        }
        _cooldown -= Time.deltaTime;
    }

    private void SpawnHuman()
    {
        var position = spawnPoint.position;
        var h = Instantiate(humanPrefab, position, Quaternion.identity);
        var houseId = GameController.Instance.GetRandomHouseId();
        h.GetComponent<HumanController>().SetupHuman(GameController.Instance.GetHousePosition(houseId), position, () =>
        {
            GameController.Instance.HumanPaid(houseId);
        });
    }
}
