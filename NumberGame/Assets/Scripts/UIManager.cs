using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] StageManager stageManager;
        [SerializeField] Player.NumberManager numberManager;
        [SerializeField] Text timeText;
        [SerializeField] Text scoreText;
        [SerializeField] Text waveText;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeText.text = stageManager.RemainingTime.ToString();
            waveText.text = "Wave " + stageManager.waveLevel.ToString();
            scoreText.text = "Score " + numberManager.score.ToString(); 
        }
    }
}

