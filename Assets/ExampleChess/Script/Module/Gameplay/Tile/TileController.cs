using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Framework.Entity;
using Example.Module.Block;

namespace Example.Module.Tile
{
    public class TileController : Controller<TileData, ITileData>, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private Button _tileButton;
        [SerializeField]
        private Image _attackZone;
        [SerializeField]
        private Sprite _emptyZone;

        private UnityAction<int, int> _onTileClick;
        private UnityAction<int, int> _onTileEnter;
        private UnityAction<int, int> _onTileExit;

        public void InitCallback(int rowPosition, int columnPosition, UnityAction<int, int> onTileEnter, UnityAction<int, int> onTileClick, UnityAction<int, int> onTileExit)
        {
            _data.RowPosition = rowPosition;
            _data.ColumnPosition = columnPosition;
            _onTileEnter += onTileEnter;
            _onTileClick += onTileClick;
            _onTileExit += onTileExit;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_data.Block == null)
            {
                _onTileEnter.Invoke(_data.RowPosition, _data.ColumnPosition);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_data.Block == null)
            {
                _onTileExit.Invoke(_data.RowPosition, _data.ColumnPosition);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_data.Block == null)
            {
                _onTileClick.Invoke(_data.RowPosition, _data.ColumnPosition);
            }
        }

        public void ShowAttackZone()
        {
            _attackZone.gameObject.SetActive(true);
        }

        public void HideAttackZone()
        {
            _attackZone.gameObject.SetActive(false);
        }

        public void SetBlock(BlockBase block)
        {
            _data.Block = block;
            _tileButton.interactable = false;
            SetImage(_data.Block.Image);
        }

        public void SetImage(Sprite block)
        {
            Image tileImage = GetComponent<Image>();
            tileImage.sprite = (block != null) ? block : _emptyZone;
        }

        public void ClearBlock()
        {
            _data.Block = null;
            _tileButton.interactable = true;
            SetImage(null);
        }
    }
}
