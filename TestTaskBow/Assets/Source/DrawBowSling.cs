using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBowSling : MonoBehaviour
{
    [SerializeField] private LineRenderer _backLine;
    [SerializeField] private LineRenderer _frontLine;

    [SerializeField] private Transform _backLineStart;
    [SerializeField] private Transform _frontLineStart;
    [SerializeField] private Transform _middlePoint;

    private void Start()
    {
        DrawStartSling();
    }
    public void Draw(Vector2 arrowPosition)
    {
        _frontLine.SetPosition(0, arrowPosition);
        _frontLine.SetPosition(1, _frontLineStart.position);

        _backLine.SetPosition(0, arrowPosition);
        _backLine.SetPosition(1, _backLineStart.position);
    }
    public void DrawStartSling()
    {
        _frontLine.SetPosition(0, _middlePoint.position);
        _frontLine.SetPosition(1, _frontLineStart.position);

        _backLine.SetPosition(0, _middlePoint.position);
        _backLine.SetPosition(1, _backLineStart.position);
    }
}
