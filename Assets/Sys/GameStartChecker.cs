using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sys
{
    public class GameStartChecker : MonoBehaviour
    {
        [SerializeField] private GameObject startPannel;
        [SerializeField] private TextMeshProUGUI vsText;

        private void Awake()
        {
            StartCoroutine(StartGameFlow());
        }

        private void Start()
        {
            vsText.text = "VS";
        }

        private void Update()
        {
            Check();
        }

        private void Check()
        {
            if (Selector.gameStartCount < 2) return;
            StartCoroutine(ThreeTwoOneFlow());
            Selector.gameStartCount = 0;
        }

        private IEnumerator ThreeTwoOneFlow()
        {
            for (var i = 3; i > 0; i --)
            {
                vsText.text = i.ToString();
                yield return new WaitForSeconds(1);
            }
            SceneManager.LoadScene("SampleScene");
        }

        private IEnumerator StartGameFlow()
        {
            yield return new WaitForSeconds(1f);
            startPannel.SetActive(false);
        }
    }
}
