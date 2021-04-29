using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBilder))]
public class Tower : MonoBehaviour
{
    private TowerBilder _towerBuilder;
    private List<Block> _blocks;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBilder>();
        _blocks = _towerBuilder.BuildPlatform();

        foreach(var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hitedBlock);

        foreach( var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y / 4, block.transform.position.z);
        }
    }
}
