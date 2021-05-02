using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(Guard))]
public class FieldofViewEditor : Editor
{
    private void OnSceneGUI()
    {
        Guard fow = (Guard)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2 + 90, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2 + 90, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        foreach(Transform visableTarget in fow.visableTargets) {
            Handles.DrawLine(fow.transform.position, visableTarget.position);
        }

    }
}
