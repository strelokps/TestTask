using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationProduct : MonoBehaviour
{
    [SerializeField] private float _productionFrequency;
    private GameObject _storageForComponents;
    private GameObject _storageForSelfProduct;
    private Components _componentsFor;
    private Components _componentsSelf;
    private float _repeat;

    public void SetComponets(Components locComponentsFor, Components locComponentsSelf,
        GameObject locStorageForComponents, GameObject locStorageForSelfProduct)
    {
        _repeat = 0.02f;
        if (_productionFrequency <= 0)
            _productionFrequency = 1f;

        _componentsFor = locComponentsFor;
        _componentsSelf = locComponentsSelf;
        _storageForComponents = locStorageForComponents;
        _storageForSelfProduct = locStorageForSelfProduct;

        StartCoroutine("RepeatGenerationProduct");
    }


    IEnumerator GenerationProduct_cor()
    {
        yield return new WaitForSeconds(_productionFrequency - _repeat);
        if (_componentsFor != null & _storageForComponents != null)
        {
            //if (_storageForComponents.)
        }

        StartCoroutine("RepeatGenerationProduct");
    }

    IEnumerator RepeatGenerationProduct()
    {
        yield return new WaitForSeconds(0.02f);
        StartCoroutine("GenerationProduct_cor");
    }
}
