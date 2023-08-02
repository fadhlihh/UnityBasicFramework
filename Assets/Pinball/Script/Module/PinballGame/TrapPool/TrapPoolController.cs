using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;
using Pinball.Module.Trap;
using Pinball.Messages;

namespace Pinball.Module.TrapPool
{
    public class TrapPoolController : Controller<TrapPoolData>
    {
        [SerializeField]
        private TrapController _trapPrefabs;
        [SerializeField]
        private List<Transform> _spawnPoints = new List<Transform>();

        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            StartCoroutine(SpawnTrap(_data.SpawnDelay));
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            Subscribe<DestroyTrapMessage>(DestroyTrap);
        }

        private void SpawnTrapObject()
        {
            Vector3 spawnPoint = GetSpawnPoint();
            TrapController trap = Instantiate<TrapController>(_trapPrefabs, spawnPoint, Quaternion.identity);
            trap.InitObject();
            _data.Traps.Add(trap);
        }

        private Vector3 GetSpawnPoint()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            bool hasTrapSpawnedInThisPoint = _data.Traps.Exists(item => item.gameObject.transform.position == _spawnPoints[spawnPointIndex].position);
            if (hasTrapSpawnedInThisPoint)
            {
                return GetSpawnPoint();
            }
            else
            {
                return _spawnPoints[spawnPointIndex].position;
            }
        }

        private IEnumerator SpawnTrap(float spawnDelay)
        {
            if (!_data.IsSpawning)
            {
                _data.IsSpawning = true;
                while (_data.Traps.Count < _data.MaxTrapAmount)
                {
                    yield return new WaitForSeconds(spawnDelay);
                    bool isSpawnPointAvailable = (_spawnPoints.Count > 0) && (_spawnPoints.Count >= _data.Traps.Count);
                    if (isSpawnPointAvailable)
                    {
                        Debug.Log("Spawn Trap");
                        SpawnTrapObject();
                    }
                }
                _data.IsSpawning = false;
            }
        }

        private void DestroyTrap(DestroyTrapMessage message)
        {
            TrapController trap = message.Trap.GetComponent<TrapController>();
            _data.Traps.Remove(trap);
            Destroy(trap.gameObject);
            StartCoroutine(SpawnTrap(_data.SpawnDelay));
        }
    }
}
