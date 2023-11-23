using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class ChangeZone : NeedLinksObject
{
    [SerializeField] protected TMP_Text Text;

    protected int ChangeDelta;

    private int _minDeltaValue = 5;
    private int _maxDeltaValue = 15;

    private void Start()
    {
        ChangeDelta = Random.Range(_minDeltaValue, _maxDeltaValue);
        ChangeDeltaText();
    }

    protected void ChangeDeltaText()
    {
        Text.text = ChangeDelta.ToString();
    }
}