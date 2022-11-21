using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private GameObject _storageForComponents;
    private GameObject _storageForSelfProduct;
    private Components _componentsFor;
    private Components _componentsSelf;

    private void Start()
    {


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


    }
}
