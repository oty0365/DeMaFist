using System;
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
        private Action _movement;
        public static PlayerType teamAPick;
        public static PlayerType teamBPick;
        public static int gameStartCount;
        private void Start()
        {
            gameStartCount = 0;
            currentIdx = 0;
            determined = false;
            if (team == PlayerTeam.TeamA)
            {
                _movement = AMovement;
            }
            else
            {
                _movement = BMovement;
            }
        }
        
        private void Update()
        {
            CheckPlayer();
            Debug.Log(teamAPick+teamBPick.ToString());
        }

        private void CheckPlayer()
        {
            _movement.Invoke();
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
            ASelection();
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
            BSelection();
        }

        private void ASelection()
        {
            playerPortrait.sprite=championsArray.championsArray[currentIdx].GetComponent<PlayerPostData>().portrait;
            teamAPick = championsArray.championsArray[currentIdx].GetComponent<PlayerPostData>().ChampionType;
            gameStartCount++;
        }

        private void BSelection()
        {
            playerPortrait.sprite=championsArray.championsArray[currentIdx].GetComponent<PlayerPostData>().portrait;
            teamBPick = championsArray.championsArray[currentIdx].GetComponent<PlayerPostData>().ChampionType;
            gameStartCount++;
        }
        
    }
}
