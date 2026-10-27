using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float Elapsed;
    public float Duration { get; private set; }

    public Tween (Transform target, Vector3 startPos, Vector3 endPos, float duration) 
    {
        Target = target;
        StartPos = startPos;
        EndPos = endPos;
        Elapsed = 0;
        Duration = duration;
    }
}
