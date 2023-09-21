using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject dotPrefab;
    public List<Vector3> positions = new List<Vector3>();

    private void Start()
    {
        GenerateOutwards(Vector3.zero, 20, 0.2f);
    }

     void GenerateOutwards(Vector3 origin, int degrees, float spacing)
    {
        positions = new List<Vector3>();

        positions.Add(origin);

        List<Vector3> outerPositions = new List<Vector3>();
        outerPositions.Add(origin);

        for (int i = 0; i < degrees; i++)
        {
            List<Vector3> newPositions = new List<Vector3>();

            foreach (Vector3 position in outerPositions)
            {
                for (int j = 0; j < 6; j++)
                {
                    float currentRadian = (float)j / 6 * 2 * Mathf.PI;
                    float newX = position.x + Mathf.Cos(currentRadian) * spacing;
                    float newY = position.y + Mathf.Sin(currentRadian) * spacing;
                    float roundNewX = Mathf.Round(newX * 100f) / 100f;
                    float roundNewY = Mathf.Round(newY * 100f) / 100f;
                    Vector3 newPosition = new Vector3(roundNewX, roundNewY, 0);

                    if (!positions.Contains(newPosition))
                    {
                        positions.Add(newPosition);
                    }

                    if (!newPositions.Contains(newPosition))
                    {
                        newPositions.Add(newPosition);
                    }
                }
            }

            outerPositions = new List<Vector3>(newPositions);
        }

        SpawnDots(positions);
    }

    void SpawnDots(List<Vector3> positions)
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(dotPrefab, position, Quaternion.identity, this.transform);
        }
    }
}
