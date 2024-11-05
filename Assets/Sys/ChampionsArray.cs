using UnityEngine;
using UnityEngine.UI;

namespace Sys
{
    public class ChampionsArray : MonoBehaviour
    {
        public GameObject[] championsArray;
        private GridLayoutGroup _gridLayout;
        public int count;
        private void Start()
        {
            _gridLayout = GetComponent<GridLayoutGroup>();
            count = _gridLayout.constraintCount;
        }
        
        void Update()
        {
        
        }
    }
}
