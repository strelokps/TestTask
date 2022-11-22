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
    private Transform _transformUIText;


    private void Start()
    {
        for (int i = 0; i < UImain._uiMainCanvasText.Length; i++)
        {
            if (UImain._uiMainCanvasText[i].CompareTag(gameObject.name))
                _transformUIText = UImain._uiMainCanvasText[i];
        }


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

    public void OnOffUIText()
    {
        if (_transformUIText.gameObject.activeSelf)
        {
            _transformUIText.gameObject.SetActive(false);
        }
        else
        {
            _transformUIText.gameObject.SetActive(true);
            StartCoroutine("OffUIText");
        }


    }

    IEnumerator OffUIText()
    {
        yield return new WaitForSeconds(4f);
        OnOffUIText();
    }
}
