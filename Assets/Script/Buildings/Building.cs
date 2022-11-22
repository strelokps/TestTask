using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private GameObject _storageForComponents;
    private GameObject _storageForSelfProduct;
    //можно грузить через ScriptableObject
    [SerializeField] private GameObject _componentForProduction;
    [SerializeField] private GameObject _componentSelf;
    private GenerationProduct _generationProduct;


    private void Start()
    {
        _generationProduct = GetComponent<GenerationProduct>();
        if (_generationProduct == null) Debug.LogError("_generationProduct = null");

        foreach (Transform child in transform)
        {
            if (child != null && child.CompareTag("StorageForComponents") )
            {
                _storageForComponents = child.gameObject;

            }
            else if (child != null && child.CompareTag("StorageForSelfProduct"))
            {
                _storageForSelfProduct = child.gameObject;
            }
        }
        _generationProduct.SetComponents(_componentSelf, _storageForComponents,
            _storageForSelfProduct);

    }

    private void PushConponentOnStorage(GameObject locGOComponent)
    {
        _storageForSelfProduct.GetComponent<Storage>().PushComponent(locGOComponent);
    }
}
