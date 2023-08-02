using UnityEngine;
using TMPro;

namespace RecyclerViewExample
{
    public class PeopleItem : MonoBehaviour
    {
        private int _id;
        private string _name;
        private int _age;
        private string _profession;

        [SerializeField]
        private TMP_Text _nameText;
        [SerializeField]
        private TMP_Text _ageText;
        [SerializeField]
        private TMP_Text _professionText;

        public void BindData(int id, string name, int age, string profession)
        {
            _id = id;
            _name = name;
            _age = age;
            _profession = profession;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _nameText.text = _name;
            _ageText.text = _age.ToString();
            _professionText.text = _profession;
        }
    }
}
