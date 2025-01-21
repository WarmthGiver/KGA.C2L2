using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private int time;

    private void Start()
    {
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
