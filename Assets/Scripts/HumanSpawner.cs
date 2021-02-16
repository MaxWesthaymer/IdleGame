using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    #region InspectorFields
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject humanPrefab;
    #endregion

    #region PrivateFields
    private GameController _gameController;
    private float _spawnRate;
    private float _cooldown;
    #endregion
    
    #region UnityMethods
    private void Start()
    {
        _gameController = GameController.Instance;
        _spawnRate = _gameController.HumansSpawnRate;
    }

    void Update()
    {
        if (_cooldown <= 0)
        {
            SpawnHuman();
            _cooldown = _spawnRate;
        }
        _cooldown -= Time.deltaTime;
    }
    #endregion

    #region PrivateMethods
    private void SpawnHuman()
    {
        var position = spawnPoint.position;
        var h = Instantiate(humanPrefab, position, Quaternion.identity);
        var houseId = _gameController.GetRandomHouseId();
        h.GetComponent<HumanController>().SetupHuman(_gameController.GetHousePosition(houseId), position, () =>
        {
            _gameController.HumanPaid(houseId);
        });
    }
    #endregion
}
