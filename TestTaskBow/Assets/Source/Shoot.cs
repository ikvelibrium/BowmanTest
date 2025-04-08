using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D SlingRb;

  
    [SerializeField] private float _maxDistanceToPool = 3;
    [SerializeField] private DrawBowSling _drawSling;
    [SerializeField] private SkeletonAnimation _bowman;
    [SerializeField] private GameObject _back;
    [SerializeField] private Line _line;
    [SerializeField] private SpringJoint2D _springJoint;
    private Rigidbody2D _rb;
    private bool _isPressed = false;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.isKinematic = false;
    }
    void Update()
    {
        if (_isPressed)
        {

            Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _drawSling.Draw(_back.transform.position);
           
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
    private void OnMouseDown()
    {
        ArrowPressed(true);
    }


    private void OnMouseUp()
    {
        ArrowUnleashed(false);
    }
    public void ArrowPressed(bool isPressed)
    {
        _isPressed = isPressed;
        _rb.isKinematic = isPressed;
        _bowman.state.SetAnimation(2,"attack_start",false);
        _line.DrawTrajectory(_rb.transform.position, );
        
    }

    public void ArrowUnleashed(bool isPressed)
    {
        _isPressed = isPressed;
        _rb.isKinematic = isPressed;
        _drawSling.DrawStartSling();
        _bowman.state.SetAnimation(2, "attack_finish", false);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(1);
       
    }


}

