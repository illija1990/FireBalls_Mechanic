using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public event UnityAction<Block> BulletHit;
    public MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Break() // вызыват пуля еогда попадает в блок
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

}
