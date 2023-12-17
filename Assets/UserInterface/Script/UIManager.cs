using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Sprite _sprite;
    [Header("Input Field")]
    [SerializeField]
    private TMP_Text _someText;
    [SerializeField]
    private TMP_InputField _inputField;
    [Header("Toggle")]
    [SerializeField]
    private Toggle _toggle;
    [SerializeField]
    private TMP_Text _toggleText;
    [Header("Slider")]
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TMP_Text _sliderText;
    [Header("Dropdown")]
    [SerializeField]
    private TMP_Dropdown _dropdown;
    [SerializeField]
    private TMP_Text _dropdownText;
    [Header("Toggle Group")]
    [SerializeField]
    private TMP_Text _toggleGroupText;
    [SerializeField]
    private Toggle _toggleOptionA;
    [SerializeField]
    private Toggle _toggleOptionB;
    [SerializeField]
    private Toggle _toggleOptionC;


    public void LoadImage()
    {
        // Sprite sprite = Resources.Load<Sprite>("Image/agate");
        _image.sprite = _sprite;
    }

    public void ChangeText()
    {
        _someText.text = _inputField.text;
    }

    public void OnToggleChange(bool value)
    {
        _toggleText.text = value.ToString();
    }

    public void OnSliderChange(float value)
    {
        float sliderValue = value * 100;
        _sliderText.text = sliderValue.ToString("#.##") + "%";
    }

    public void OnDropdownChange(int value)
    {
        _dropdownText.text = _dropdown.options[value].text;
    }

    public void OnToggleOptionA(bool value)
    {
        if (value == true)
        {
            _toggleGroupText.text = "Option A";
        }
    }

    public void OnToggleOptionB(bool value)
    {
        if (value == true)
        {
            _toggleGroupText.text = "Option B";
        }
    }

    public void OnToggleOptionC(bool value)
    {
        if (value == true)
        {
            _toggleGroupText.text = "Option C";
        }
    }

    private void Start()
    {
        _inputField.text = "Default Text";
        _toggleText.text = _toggle.isOn.ToString();
        float sliderValue = _slider.value * 100;
        _sliderText.text = sliderValue.ToString("0") + "%";
        int dropdownValue = _dropdown.value;
        _dropdownText.text = _dropdown.options[dropdownValue].text;
    }
}
