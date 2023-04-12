using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScorePlayer1;
    [SerializeField] private TextMeshProUGUI textScorePlayer2;

    private void Start()
    {
        GameController.Instance.ScoredChanged += GameController_ScoredChanded;
    }

    private void GameController_ScoredChanded(object sender, GameController.ScoredChangedEventArgs e)
    {
        switch (e.sideThatScored)
        {
            case Side.Left:
                textScorePlayer1.text = e.score.ToString();
                break;

            case Side.Right:
                textScorePlayer2.text= e.score.ToString();
                break;
        }
    }
}
