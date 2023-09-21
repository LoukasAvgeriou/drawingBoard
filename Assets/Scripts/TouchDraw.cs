using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{
    public static TouchDraw instance;
    public List<LineRenderer> lines = new List<LineRenderer>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    [SerializeField] GameObject linePrefab;
    LineRenderer currentLine;

    public static void StartLine(Vector3 position)
    {
        GameObject lineGameObject = GameObject.Instantiate(instance.linePrefab, Vector3.zero, Quaternion.identity);
        instance.currentLine = lineGameObject.GetComponent<LineRenderer>();
        instance.currentLine.positionCount = 2;
        instance.currentLine.SetPosition(0, position);
        instance.currentLine.SetPosition(1, position);
    }

    public static void UpdateLine(Vector3 position)
    {
        instance.currentLine.SetPosition(1, position);
    }

    public void FinishLine(Vector3 position)
    {
        lines.Add(instance.currentLine);
        instance.currentLine = null;
    }


}
