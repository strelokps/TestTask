using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Transform[] _uiCanvasText;

    private void Start()
    {
        FillTextArray();
    }

    private void FillTextArray()
    {
        var coutChild = transform.childCount;
        _uiCanvasText = new Transform[coutChild];
        for (int i = 0; i < coutChild; i++)
        {
            _uiCanvasText[i] = transform.GetChild(i);
        }
        UImain._uiMainCanvasText = _uiCanvasText;
    }

    
}
