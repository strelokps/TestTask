using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RepeatGenerationProduct");
    }

    IEnumerator GenerationProduct_cor()
    {
        Debug.Log("Start ���������");
        yield return new WaitForSeconds(1);
        Debug.Log("���������");
        StartCoroutine("RepeatGenerationProduct");
    }

    IEnumerator RepeatGenerationProduct()
    {
        yield return new WaitForSeconds(0.02f);
        StartCoroutine("GenerationProduct_cor");
    }
}
