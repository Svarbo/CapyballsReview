using System;
using UnityEngine.UI;

public class LevelButtonListener
{
    private Button _button;
    private Action _action;

    public LevelButtonListener(Button button, Action action)
    {
        _button = button;
        _action = action;
    }

    public void Create() =>
        _button.onClick.AddListener(OnClick);

    public void Destroy() =>
        _button.onClick.RemoveListener(OnClick);

    private void OnClick() =>
        _action.Invoke();
}