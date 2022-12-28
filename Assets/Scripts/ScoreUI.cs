using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Player1;
    [SerializeField] private TextMeshProUGUI TMP_Player2;

    private void Start()
    {
        GameController.Instance.OnScoredChanded += GameController_OnScoredChanded;
    }

    private void GameController_OnScoredChanded(object sender, GameController.ScoredChandedEventArgs e)
    {
        switch (e.sideThatScored)
        {
            case Side.Left:
                TMP_Player1.text = e.score.ToString();
                break;

            case Side.Right:
                TMP_Player2.text= e.score.ToString();
                break;
        }
    }
}
