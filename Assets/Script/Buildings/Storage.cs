using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    private int _countChild;
    private Transform[] _arrCellStorage;
    [SerializeField] private List<Transform> _emptyCellStorage;
    [SerializeField] private List<Transform> _fillCellStorage;
    private int _countEmptyArr;
    private int _countFillArr;
    private Text _uiTestOutSpace;



    private void Start()
    {
        _countEmptyArr = 0;
        _countFillArr = 0;
        _countChild = transform.childCount;
        _emptyCellStorage = new List<Transform>();
        _fillCellStorage = new List<Transform>();
        _arrCellStorage = new Transform[_countChild];
        for (int i = 0; i < _countChild; i++)
        {
            _arrCellStorage[i] = gameObject.transform.GetChild(i);
            SetTryEmptyCell(_arrCellStorage[i]);
        }
    }



    //public Transform[] GetArrCellStorage()
    //{
    //    return _arrCellStorage;
    //}

    //public void ModifyArrCellStorage(Transform[] locArrCellStorage)
    //{
    //    _arrCellStorage = locArrCellStorage;
    //}

    public List<Transform> GetEmptyCellStorage()
    {
        _emptyCellStorage.Clear();
        var emptyCell = GetComponent<CellStorage>();

        for (int i = 0; i < _arrCellStorage.Length; i++)
        {
            emptyCell = _arrCellStorage[i].GetComponent<CellStorage>();

            if (emptyCell.transform.childCount == 0)
            {

                _emptyCellStorage.Add(_arrCellStorage[i]);
            }
        }
        return _emptyCellStorage;
    }

   


    public List<Transform> GetFillCellStorage()
    {
        _fillCellStorage.Clear();
        var fillCell = GetComponent<CellStorage>();

        for (int i = 0; i < _arrCellStorage.Length; i++)
        {
            fillCell = _arrCellStorage[i].GetComponent<CellStorage>();

            if (!fillCell.empty)
            {

                _fillCellStorage.Add(_arrCellStorage[i]);
            }
        }
        return _fillCellStorage;
    }

    //Кладем компоненту на склад
    public bool PushComponent(GameObject locComponent)
    {
        bool returnFlag = false;
        var emptyCell = GetComponent<CellStorage>();

        for (int i = 0; i < _arrCellStorage.Length; i++)
        {
            if (_arrCellStorage[i].childCount == 0)
            {
                GameObject tempComp = GenerateComponet(locComponent);
                emptyCell = _arrCellStorage[i].GetComponent<CellStorage>();
                emptyCell.Component = tempComp;
                var p = emptyCell.Component.transform.localPosition;
                tempComp.transform.SetParent(emptyCell.transform);
                tempComp.transform.localPosition = new Vector3(0f, 0.2f, 0f);
                tempComp.transform.rotation = emptyCell.Component.transform.rotation;

                //emptyCell.Component.transform.localScale = locComponent.transform.localScale;
                emptyCell.empty = false;
                emptyCell.typeComponent = tempComp.GetComponent<Components>()._prpType;
                returnFlag = true;
                break;
            }
        }

        return returnFlag;
    }

    //Заюираем компоненту со склада
    public bool PullComponent(GameObject locComponent)
    {
        bool returnFlag = false;
        var fillCell = GetComponent<CellStorage>();
        for (int i = 0; i < _arrCellStorage.Length; i++)
        {
            if (_arrCellStorage[i].GetComponent<CellStorage>().empty)
            {
                fillCell = _arrCellStorage[i].GetComponent<CellStorage>();
                locComponent.transform.SetParent(fillCell.transform);
            }
        }
        return returnFlag;
    }

    private void SetTryEmptyCell(Transform locCellTransform)
    {
        if (locCellTransform.childCount == 0)
        {
            locCellTransform.GetComponent<CellStorage>().empty = true;
        }
    }

    private GameObject GenerateComponet(GameObject locGOComponent)
    {
        GameObject componet = Instantiate(locGOComponent, this.transform.position, Quaternion.identity) as GameObject;
        return componet;

    }

}
