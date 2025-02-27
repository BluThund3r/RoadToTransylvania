using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private float _spawnDelay = 0.5f;
    [SerializeField] private float _spawnRadius = 10f;  
    [SerializeField] public int _spawnCount = 5;
    private bool _alreadySpawned = false;
    public EnemyType EnemyType;

    private IEnumerator SpawnEnemies() {
        _alreadySpawned = true;
        for(int i = 0; i < _spawnCount; i++) {
            var randomOffsetPoint = Random.insideUnitSphere * _spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffsetPoint.x, 0, randomOffsetPoint.z);
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnDelay);
        }
        yield return null;

        Destroy(gameObject); // uncomment this line to destroy the spawner after spawning enemies
    }

    private void OnTriggerEnter(Collider other) {
        if(!_alreadySpawned && other.CompareTag("Player")) {
            StartCoroutine(SpawnEnemies());
        }
    }
}
