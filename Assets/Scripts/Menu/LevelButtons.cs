using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons = new List<Button>();
    [SerializeField] private List<Image> _closingImages = new List<Image>();

    private int _openLevelsNumber;

    private void Start()
    {
        _openLevelsNumber = PlayerPrefs.GetInt("OpenLevelsNumber");
        ShowOpenLevels();
    }

    private void ShowOpenLevels()
    {
        for (int i = 0; i < _openLevelsNumber; i++)
        {
            _buttons[i].interactable = true;
            _closingImages[i].gameObject.SetActive(false);
        }
    }
}