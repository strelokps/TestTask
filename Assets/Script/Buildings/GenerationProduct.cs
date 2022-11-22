using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationProduct : MonoBehaviour
{
    [SerializeField] private float _productionFrequency;
    private GameObject _storageForComponents;
    private GameObject _storageForSelfProduct;
    private GameObject _componentsFor;
    private GameObject _componentsSelf;
    private float _repeat;
    private Storage _storage;


    public void SetComponents(GameObject locComponentsSelfProduct,
        GameObject locStorageForComponents, GameObject locStorageForSelfProduct)
    {
        _repeat = 0.02f;
        if (_productionFrequency <= 0)
            _productionFrequency = 1f;

        _componentsSelf = locComponentsSelfProduct;
        _storageForComponents = locStorageForComponents;
        _storageForSelfProduct = locStorageForSelfProduct;
        _storage = _storageForSelfProduct.GetComponent<Storage>();
        StartCoroutine("RepeatGenerationProduct");
    }


    IEnumerator GenerationProduct_cor()
    {
        yield return new WaitForSeconds(_productionFrequency - _repeat);
        if (_componentsSelf != null & _storageForSelfProduct != null)
        {
            if (_storage.GetEmptyCellStorage().Count > 0)
            {
                _storage.PushComponent(_componentsSelf);
            }

            Debug.Log($"count = {_storage.GetEmptyCellStorage().Count}");
        }
        StartCoroutine("RepeatGenerationProduct");
    }

    IEnumerator RepeatGenerationProduct()
    {
        yield return new WaitForSeconds(0.02f);
        StartCoroutine("GenerationProduct_cor");
    }

   
}
