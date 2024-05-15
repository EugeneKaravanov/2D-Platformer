using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VampireAttackCounter : MonoBehaviour
{
    [SerializeField] private VamireAttacker _vampireAttacker;

    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _vampireAttacker.DurationLeftChanged += ChangeCounter;
    }

    private void OnDisable()
    {
        _vampireAttacker.DurationLeftChanged -= ChangeCounter;
    }

    private void ChangeCounter()
    {
        if (_vampireAttacker.DurationLeft != 0) 
        {
            _textMeshProUGUI.text = Convert.ToString(_vampireAttacker.DurationLeft);
        }
        else
        {
            _textMeshProUGUI.text = "";
        }
    }
}
