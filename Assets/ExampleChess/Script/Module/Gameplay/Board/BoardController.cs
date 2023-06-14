using System.Collections.Generic;
using UnityEngine;
using Framework.Entity;
using Example.Scene;
using Example.Messages;
using Example.Module.Tile;
using Example.Module.Block;
using Example.Module.Score;

namespace Example.Module.Board
{
    public class BoardController : Controller<BoardData>
    {
        [SerializeField]
        private Transform _board;
        [SerializeField]
        private GameObject _tilePrefab;

        private TileController[,] _tiles;
        private List<TileController> _attackedTilesPool = new List<TileController>();
        private List<TileController> _placedTiles = new List<TileController>();
        private BlockController _block;
        private ScoreController _score;



        protected override void OnControllerStart()
        {
            base.OnControllerStart();
            _tiles = new TileController[_data.Row, _data.Column];
            _block = GameplayLauncher.Instance.Block;
            _score = GameplayLauncher.Instance.Score;
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            for (int rowIndex = 0; rowIndex < _data.Row; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _data.Column; columnIndex++)
                {
                    GameObject tileObject = Instantiate(_tilePrefab, _board);
                    tileObject.name = $"Tile {rowIndex + 1},{columnIndex + 1}";
                    tileObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(columnIndex * _data.Spacing, rowIndex * -_data.Spacing);
                    TileController tileController = tileObject.GetComponent<TileController>();
                    tileController.InitCallback(rowIndex, columnIndex, OnEnterTile, OnPlaceBlock, OnExitTile);
                    _tiles[rowIndex, columnIndex] = tileController;
                }
            }
        }

        private void OnPlaceBlock(int rowPosition, int columnPosition)
        {
            BlockBase block = _block.Data.Block;
            TileController tile = _tiles[rowPosition, columnPosition];
            tile.SetBlock(block);
            bool isAttacking = CheckAttack();
            if (!isAttacking)
            {
                _block.SpawnNextBlock();
                // _score.AddScore(block.Score);
                SendMessage<AddScoreMessage>(new AddScoreMessage(block.Score));
                TriggerEvent("ResetTimer");
                _placedTiles.Add(tile);
                CheckPlacedTiles(block, 3);
                ClearAttack();
            }
        }

        private void OnEnterTile(int rowPosition, int columnPosition)
        {
            BlockBase block = _block.Data.Block;
            _tiles[rowPosition, columnPosition].SetImage(block.Image);
            ShowAttack(rowPosition, columnPosition);
        }

        private void OnExitTile(int rowPosition, int columnPosition)
        {
            ClearAttack();
            _tiles[rowPosition, columnPosition].SetImage(null);
        }

        private void ClearAttack()
        {
            foreach (TileController tile in _attackedTilesPool)
            {
                tile.HideAttackZone();
            }
            _attackedTilesPool.Clear();
        }

        private void ShowAttack(int rowPosition, int columnPosition)
        {
            BlockBase block = _block.Data.Block;
            if (block != null)
            {
                block.SetAttackZone(rowPosition, columnPosition, _data.Column, _data.Row);
                if (block.AttackZone.Count > 0)
                {
                    foreach (AttackZone attackZone in block.AttackZone)
                    {
                        TileController tile = _tiles[attackZone.Row, attackZone.Column];
                        tile.ShowAttackZone();
                        _attackedTilesPool.Add(tile);
                    }
                }
            }
        }

        private bool CheckAttack()
        {
            foreach (TileController tile in _attackedTilesPool)
            {
                if (tile.Data.Block != null)
                {
                    TriggerEvent("GameOver");
                    return true;
                }
            }
            return false;
        }

        private void CheckPlacedTiles(BlockBase block, int blockCount)
        {
            if (_placedTiles.Count > 0)
            {
                List<TileController> checkedTiles = _placedTiles.FindAll(item => string.Equals(item.Data.Block.name, block.name));
                Debug.Log(checkedTiles.Count);
                if (checkedTiles.Count >= blockCount)
                {
                    foreach (TileController tile in checkedTiles)
                    {
                        tile.ClearBlock();
                        _placedTiles.Remove(tile);
                    }
                }
            }
        }
    }
}
