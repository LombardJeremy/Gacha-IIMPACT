using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour
{
    [SerializeField] private Transform _Grid2X2;
    [SerializeField] private Transform _Grid3X3;
    [SerializeField] private Transform _Grid4X4;
    

    private int _actualGridDisposition;
    
    
    [SerializeField] private List<string> buttonNames = new List<string>();
    public List<Transform> _cardsCollection = new List<Transform>();
    
    [SerializeField] private Button _changeGridButton;

    private void Start()
    {
        _Grid2X2.gameObject.SetActive(true);
        _Grid3X3.gameObject.SetActive(false);
        _Grid4X4.gameObject.SetActive(false);
        
        SetNewButtonName(_actualGridDisposition);
    }

    public void ChangeGrid()
    {
        _actualGridDisposition++;
        if (_actualGridDisposition > 2)
        {
            _actualGridDisposition = 0;
        }
        SetNewGrid(_actualGridDisposition);
        SetNewButtonName(_actualGridDisposition);
    }

    private void SetNewGrid(int index)
    {
        Transform newParent = null;
        switch (index)
        {
            case 0:
                // 2x2
                _Grid2X2.gameObject.SetActive(true);
                _Grid3X3.gameObject.SetActive(false);
                _Grid4X4.gameObject.SetActive(false);
                
                newParent = _Grid2X2;
                break;
            case 1:
                // 3x3
                _Grid2X2.gameObject.SetActive(false);
                _Grid3X3.gameObject.SetActive(true);
                _Grid4X4.gameObject.SetActive(false);
                
                newParent = _Grid3X3;
                break;
            case 2:
                // 4x4
                _Grid2X2.gameObject.SetActive(false);
                _Grid3X3.gameObject.SetActive(false);
                _Grid4X4.gameObject.SetActive(true);
                
                newParent = _Grid4X4;
                break;
        }
        ChangeCardParent(newParent);

    }
    
    private void SetNewButtonName(int index)
    {
        _changeGridButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonNames[index];
    }
    
    private void ChangeCardParent(Transform newParent)
    {
        foreach (var card in _cardsCollection)
        {
            card.SetParent(newParent);
        }
    }
}
