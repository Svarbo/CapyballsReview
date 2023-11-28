using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Image _closingImage;

        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        public void Draw()
        {
            _button.interactable = true;
            _closingImage.gameObject.SetActive(false);
        }
    }
}