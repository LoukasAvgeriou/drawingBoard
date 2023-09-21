using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public TouchDraw touchDraw;
    [SerializeField] public GameObject grid;

    public void Undo()
    {
        if (touchDraw.lines.Count > 0)
        {
            LineRenderer lastOnList = null;

            int linesCount = touchDraw.lines.Count - 1;

            lastOnList = touchDraw.lines[linesCount];

            touchDraw.lines.Remove(lastOnList);

            Destroy(lastOnList.gameObject);
        } else
        {
            return;
        }
    }

    public void DisableGrid()
    {
        grid.SetActive(false);
    }

    public void EnableGrid()
    {
        grid.SetActive(true);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
