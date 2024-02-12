using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RecoloringBehavior : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration;
    [SerializeField] private float  _delayAfterRecoloring;
    
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _recoloringTime;
    private float _delayTime;
    private void Awake()
    {

        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
    }

    private void Update()
    {
        _recoloringTime += Time.deltaTime;
        

        float progress = _recoloringTime / _recoloringDuration;
        Color currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;

        if (_recoloringTime > _recoloringDuration)
        {
            _delayTime += Time.deltaTime;
            if (_recoloringTime > _recoloringDuration + _delayAfterRecoloring)
            {
                _recoloringTime = 0;
                _delayTime = 0;
                GenerateNextColor();
            }
            
        }

        
    }

    
}