using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Components : MonoBehaviour
{
    private string _typeProduct ;
    public string _prpType
    {
        get { return _typeProduct; }
        set { _typeProduct = value; }
    }
}
