using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour, IPooledObject
{
    private TMP_Text _tmp;
    private IEnumerator _coroutine;
    public float waitTime = 0.5f;
    public Vector3 offset = new Vector3(0f, 1f, 0f);

    private void Awake()
    {
        _tmp = GetComponent<TMP_Text>();
    }
    public void OnObjectSpawn(int var)
    {
        _tmp.text = var.ToString();
        transform.position += offset;
        _coroutine = disableobject(waitTime);
        StartCoroutine(_coroutine);
    }

    private IEnumerator disableobject(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        this.gameObject.SetActive(false);
    }

}
