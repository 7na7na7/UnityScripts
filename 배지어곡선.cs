using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class 배지어곡선 : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    public int pointCount;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3[] points = new Vector3[this.pointCount];

        for (int i = 0; i < this.pointCount; i++)
            points[i] = this.GetBezierPosition(this.p0.localPosition, this.p1.localPosition, this.p2.localPosition, this.p3.localPosition, (float)i / (this.pointCount - 1));

        this.lineRenderer.positionCount = this.pointCount;
        this.lineRenderer.SetPositions(points);
    }

    private Vector3 GetBezierPosition(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 q0 = Vector3.Lerp(p0, p1, t);
        Vector3 q1 = Vector3.Lerp(p1, p2, t);
        Vector3 q2 = Vector3.Lerp(p2, p3, t);

        Vector3 r0 = Vector3.Lerp(q0, q1, t);
        Vector3 r1 = Vector3.Lerp(q1, q2, t);

        return Vector3.Lerp(r0, r1, t);
    }
}