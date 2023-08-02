using System.Collections.Generic;
using UnityEngine;

namespace RecyclerViewExample
{
    [CreateAssetMenu(fileName = "People", menuName = "People")]
    public class PeopleDataSO : ScriptableObject
    {
        [SerializeField]
        public List<People> Peoples = new List<People>();
    }
}
