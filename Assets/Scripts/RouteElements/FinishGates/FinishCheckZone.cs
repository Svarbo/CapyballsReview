using TMPro;
using UnityEngine;

public class FinishCheckZone : NeedLinksObject
{
    [SerializeField] private FinishGates _finishGates;
    [SerializeField] private TMP_Text _neededBallsText;
 
    private int _ballsCount = 0;

    private void Start()
    {
        ChangeNeededBallsText();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Ball>(out Ball ball))
        {
            _ballsCount++;
            ChangeNeededBallsText();
        }

        TryOpenGates();
        CheckGameOver();
    }

    private void ChangeNeededBallsText()
    {
        int remains = Mathf.Clamp(_finishGates.NeededBallsCount - _ballsCount, 0, _finishGates.NeededBallsCount);
        _neededBallsText.text = remains.ToString();
    }

    private bool TryOpenGates()
    {
        if (_ballsCount >= _finishGates.NeededBallsCount)
        {
            _finishGates.Open();
            Referee.ReduceScore(_finishGates.Reward);

            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckGameOver()
    {
        int playerBallsCount = Player.BallsCount;

        if (playerBallsCount == _ballsCount && playerBallsCount < _finishGates.NeededBallsCount)
            Referee.CheckWin();
    }
}