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

    private void Update()
    {
        transform.position += offset / 50;
    }
    public void OnObjectSpawn(int var)
    {
        _tmp.text = var.ToString();
        transform.position += offset;
        _coroutine = Disableobject(waitTime);
        StartCoroutine(_coroutine);
    }

    private IEnumerator Disableobject(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        this.gameObject.SetActive(false);
    }

}
