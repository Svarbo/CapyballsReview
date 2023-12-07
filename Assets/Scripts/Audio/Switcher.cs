using ConstantValues;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class Switcher : MonoBehaviour
    {
        [SerializeField] private List<SoundSource> _soundsSources = new List<SoundSource>();
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Slider _slider;

        private float _volumeValue;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
            _toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }

        private void Awake()
        {
            _volumeValue = PlayerPrefs.GetFloat(PlayerPrefsNames.Volume);

            SetSliderValue(_volumeValue);
            SetToggleValue(_volumeValue);
        }

        private void OnSliderValueChanged(float sliderValue)
        {
            PlayerPrefs.SetFloat(PlayerPrefsNames.Volume, sliderValue);

            SetCurrentVolume();
            SetToggleValue(sliderValue);
        }

        private void OnToggleValueChanged(bool toggleStatus)
        {
            if (toggleStatus)
                PlayerPrefs.SetFloat(PlayerPrefsNames.Volume, 0);
            else
                PlayerPrefs.SetFloat(PlayerPrefsNames.Volume, _volumeValue);

            SetCurrentVolume();
        }

        private void SetCurrentVolume()
        {
            foreach (SoundSource soundSource in _soundsSources)
                soundSource.SetVolume();
        }

        private void SetToggleValue(float volumeValue) =>
            _toggle.isOn = volumeValue == 0;

        private void SetSliderValue(float volumeValue) =>
            _slider.value = volumeValue;
    }
}