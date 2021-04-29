using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private List<Block> _blocks;
    [SerializeField] private Color[] _colors; 

    public List<Block> BuildPlatform()
    {
        _blocks = new List<Block>();
        Transform _currentPosition = _buildPoint;

        for(int i =0; i < _towerSize; i++)
        {
            Block newBlock = Instantiate(_block, InstantiatePosition(_currentPosition), Quaternion.identity, _buildPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _currentPosition = newBlock.transform;
            _blocks.Add(newBlock);
        }
        return _blocks;
    }

    private Vector3 InstantiatePosition(Transform _currentPosition)
    {
        return new Vector3(_currentPosition.position.x, _currentPosition.position.y + _currentPosition.localScale.y / 4, _currentPosition.position.z);
    }
}
