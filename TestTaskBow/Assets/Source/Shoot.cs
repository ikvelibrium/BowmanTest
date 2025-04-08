using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D SlingRb;

   
    [SerializeField] private int _maxDistanceToPool = 3;
    private Rigidbody2D _rb;
    private bool _isPressed = false;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        BirdPressed(true);
    }


    private void OnMouseUp()
    {
        BirdUnleashed(false);
    }
    void Update()
    {

        if (_isPressed)
        {

            Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (Vector2.Distance(_mousePosition, SlingRb.position) > _maxDistanceToPool)
            {
                _rb.position = SlingRb.position + (_mousePosition - SlingRb.position).normalized * _maxDistanceToPool;
            }
            else
            {
                _rb.position = _mousePosition;
            }
        }
    }
    public void BirdPressed(bool isPressed)
    {
        _isPressed = isPressed;
        _rb.isKinematic = isPressed;
    }

    public void BirdUnleashed(bool isPressed)
    {
        _isPressed = isPressed;
        _rb.isKinematic = isPressed;
       
    }

   
}

