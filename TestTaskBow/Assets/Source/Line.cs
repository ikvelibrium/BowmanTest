using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{ 
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] private int _trajectoryPoints;
    Vector2 _velocity;
    public void DrawTrajectory(Transform startPoint, Vector2 velocity)
    {
        Transform _startPoint = startPoint;
        _velocity = velocity;
        Vector3[] positions = new Vector3[_trajectoryPoints];
        for (int i = 0; i < _trajectoryPoints; i++)
        {
            float time = i * _trajectoryPoints;
            Vector3 pos = (Vector2)_startPoint.position + velocity * time + 0.5f * Physics2D.gravity * time * time;
            positions[i] = pos;
        }
        _lineRenderer.positionCount = _trajectoryPoints;
        _lineRenderer.SetPositions(positions);
    }
}
