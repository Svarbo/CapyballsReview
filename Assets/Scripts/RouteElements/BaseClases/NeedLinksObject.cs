using UnityEngine;

public class NeedLinksObject : MonoBehaviour
{
    protected Player Player;
    protected ObjectPool BallsPool;
    protected Referee Referee;
    protected SoundSource SoundSource;

    public void SetNeededLinks(Player player, ObjectPool ballsPool, Referee referee, SoundSource soundSource)
    {
        Player = player;
        BallsPool = ballsPool;
        Referee = referee;
        SoundSource = soundSource;
    }
}