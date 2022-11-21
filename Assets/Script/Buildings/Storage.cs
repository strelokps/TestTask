using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _countChild;
    private Transform[] _arrCellStorage;
    //private string _typeComponent = "null";



    private void Start()
    {
        _countChild = transform.childCount;
        _arrCellStorage = new Transform[_countChild];
        for (int i = 0; i < _countChild; i++)
        {
            _arrCellStorage[i] = gameObject.transform.GetChild(i);
        }
        //if (_typeComponent.CompareTo("null"))
        //{
        //    Debug.LogError("Push method SetParameter");z
        //}
        //else
        //{
            
        //}

    }

    //public void SetParameter(string locTypeComponet)
    //{
    //    _typeComponent = locTypeComponet;
    //}

    public Transform[] GetArrCellStorage()
    {
        return _arrCellStorage;
    }

    public void ModifyArrCellStorage(Transform[] locArrCellStorage)
    {
        _arrCellStorage = locArrCellStorage;
    }



}
