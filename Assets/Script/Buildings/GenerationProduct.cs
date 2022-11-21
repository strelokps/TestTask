using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationProduct : MonoBehaviour
{
    [SerializeField] private float _productionFrequency;
    [SerializeField] private GameObject _prefabProduct;
    [SerializeField] private GameObject _prefabSelfStorage;
    private float _repeat;

    private void Start()
    {
        _repeat = 0.02f;
        if (_productionFrequency <= 0)
            _productionFrequency = 1f;
        if (_prefabProduct != null && _prefabSelfStorage != null)
            StartCoroutine("RepeatGenerationProduct");

    }

    IEnumerator GenerationProduct_cor()
    {
        yield return new WaitForSeconds(_productionFrequency - _repeat);
        Debug.Log("Повторить");
        StartCoroutine("RepeatGenerationProduct");
    }

    IEnumerator RepeatGenerationProduct()
    {
        yield return new WaitForSeconds(0.02f);
        StartCoroutine("GenerationProduct_cor");
    }
}
