using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelButton : Button
    {
        [SerializeField] private Image _closingImage;

        public void Draw()
        {
            interactable = true;
            _closingImage.gameObject.SetActive(false);
        }
    }
}