using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;
using Pinball.Module.Coin;
using Pinball.Messages;

namespace Pinball.Module.CoinPool
{
    public class CoinPoolController : Controller<CoinPoolData>
    {
        [SerializeField]
        private CoinController _prefabs;
        [SerializeField]
        private List<Transform> _spawnPoints = new List<Transform>();

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            StartCoroutine(SpawnCoin(_data.SpawnDelay));
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            Subscribe<DestroyCoinMessage>(DestroyCoin);
        }

        private void SpawnCoinObject()
        {
            Vector3 spawnPoint = GetSpawnPoint();
            CoinController coin = Instantiate<CoinController>(_prefabs, spawnPoint, Quaternion.identity);
            coin.InitObject();
            _data.Coins.Add(coin);
        }

        private Vector3 GetSpawnPoint()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            bool hasCoinSpawnedInThisPoint = _data.Coins.Exists(item => item.gameObject.transform.position == _spawnPoints[spawnPointIndex].position);
            if (hasCoinSpawnedInThisPoint)
            {
                return GetSpawnPoint();
            }
            else
            {
                return _spawnPoints[spawnPointIndex].position;
            }
        }

        private IEnumerator SpawnCoin(float spawnDelay)
        {
            if (!_data.IsSpawning)
            {
                _data.IsSpawning = true;
                while (_data.Coins.Count < _data.MaxCoinAmount)
                {
                    yield return new WaitForSeconds(spawnDelay);
                    bool isSpawnPointAvailable = (_spawnPoints.Count > 0) && (_spawnPoints.Count >= _data.Coins.Count);
                    if (isSpawnPointAvailable)
                    {
                        Debug.Log("Spawn Coin");
                        SpawnCoinObject();
                    }
                }
                _data.IsSpawning = false;
            }
        }

        private void DestroyCoin(DestroyCoinMessage message)
        {
            CoinController coin = message.Coin.GetComponent<CoinController>();
            _data.Coins.Remove(coin);
            Destroy(coin.gameObject);
            StartCoroutine(SpawnCoin(_data.SpawnDelay));
        }
    }
}
