using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<NeedLinksObject> _needLinksObjects = new List<NeedLinksObject>();

    public void InsertNeededLinks(Player player, ObjectPool ballsPool, Referee referee, SoundSource soundSource)
    {
        foreach(NeedLinksObject needLinksObject in _needLinksObjects)
            needLinksObject.SetNeededLinks(player, ballsPool, referee, soundSource);
    }
}