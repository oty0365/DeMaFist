using Players;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Sys
{
    public class Selector : MonoBehaviour
    {
        public PlayerTeam team;
        [SerializeField] private Image playerPortrait;
        [SerializeField] private ChampionsArray championsArray;
        public int currentIdx;
        public bool determined;
        private void Start()
        {
            currentIdx = 0;
            determined = false;
        }
        
        private void Update()
        {
            CheckPlayer();
        }

        private void CheckPlayer()
        {
            if (team == PlayerTeam.TeamA)
            {
                AMovement();
            }
            else
            {
                BMovement();
            }
        }

        private void AMovement()
        {
            if (determined) return;
            gameObject.transform.position = championsArray.championsArray[currentIdx].transform.position;
            if (Input.GetKeyDown(KeyCode.W) && currentIdx - championsArray.count >= 0)
            {
                currentIdx -= championsArray.count;
            }
            else if (Input.GetKeyDown(KeyCode.S) &&
                     currentIdx + championsArray.count < championsArray.championsArray.Length)
            {
                currentIdx += championsArray.count;
            }
            else if (Input.GetKeyDown(KeyCode.A) && currentIdx - 1 >= 0)
            {
                currentIdx--;
            }
            else if (Input.GetKeyDown(KeyCode.D) && currentIdx + 1 < championsArray.championsArray.Length)
            {
                currentIdx++;
            }

            if (!Input.GetKeyDown(KeyCode.R)) return;
            determined = true;
            Selection();
        }

        private void BMovement()
        {
            if (determined) return;
            gameObject.transform.position = championsArray.championsArray[currentIdx].transform.position;
            if (Input.GetKeyDown(KeyCode.U)&&currentIdx-championsArray.count>=0)
            {
                currentIdx -= championsArray.count;
            }
            else if (Input.GetKeyDown(KeyCode.J) &&
                     currentIdx + championsArray.count < championsArray.championsArray.Length)
            {
                currentIdx += championsArray.count;
            }
            else if (Input.GetKeyDown(KeyCode.H) && currentIdx - 1 >= 0)
            {
                currentIdx--;
            }
            else if (Input.GetKeyDown(KeyCode.K) && currentIdx + 1 < championsArray.championsArray.Length)
            {
                currentIdx++;
            }

            if (!Input.GetKeyDown(KeyCode.O)) return;
            determined = true;
            Selection();
        }

        private void Selection()
        {
            playerPortrait.sprite=championsArray.championsArray[currentIdx].GetComponent<PlayerPostData>().portrait;
        }
        
    }
}
