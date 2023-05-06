using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _spawnInterval;

    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _minY;
    [SerializeField] private int _maxY;

    [SerializeField] private float _height;

    private float _curretSpawnTimer;

    void Update()
    {
        _curretSpawnTimer += Time.deltaTime;

        if (_curretSpawnTimer >= _spawnInterval)
        {
            var enemyInstance = Instantiate(_enemyPrefab);

            var newPosition = GenerateStartPosition();

            enemyInstance.transform.position = newPosition;

            _curretSpawnTimer = 0;
        }
        
    }

    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_minX, _maxX), _height, Random.Range(_minY, _maxY));

        return startPos;
    }
}
