using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnlimitedScrollUI;

namespace RecyclerViewExample
{
    public class PeopleList : MonoBehaviour
    {
        [SerializeField]
        private PeopleDataSO _people;
        [SerializeField]
        private GameObject _peoplePrefab;

        private IUnlimitedScroller _unlimitedScroller;

        private Stack<PeopleItem> _peopleItemPool = new Stack<PeopleItem>();

        public void Generate()
        {
            int totalCount = _people.Peoples.Count;
            _unlimitedScroller.Generate(_peoplePrefab, totalCount, (index, iCell) =>
            {
                var regularCell = iCell as RegularCell;
                People people = _people.Peoples[index];
                PeopleItem peopleItem = regularCell.GetComponent<PeopleItem>();
                peopleItem.BindData(people.Id, people.Name, people.Age, people.Profession);
                if (regularCell != null) regularCell.onGenerated?.Invoke(index);
            });
        }

        private void Start()
        {
            _unlimitedScroller = GetComponent<IUnlimitedScroller>();
            StartCoroutine(AutoGenerate());
        }

        private IEnumerator AutoGenerate()
        {
            yield return new WaitForEndOfFrame();
            Generate();
        }
    }
}
