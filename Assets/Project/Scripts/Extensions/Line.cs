using UnityEngine;

public struct Line
{
    public Vector3 startPoint;
    public Vector3 endPoint;

    public Line(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
}