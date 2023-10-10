using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour{

    public static GridGenerator Instance;


    [SerializeField] private List<Vector3> gridCells = new List<Vector3>();
    private readonly Vector2 gridResolution = new Vector2(100, 20);

    private void Awake(){
        Instance = this;
    }


    public void GenerateGrid()
    {
        // Get a reference to the main camera
        Camera mainCamera = Camera.main;

        // Calculate the step size in the X and Y directions
        float stepX = Screen.width / gridResolution.x ;
        float stepY = Screen.height / gridResolution.y;

        // Loop through the grid in the X and Y directions
        for (int x = 0; x < gridResolution.x; x++)
        {
            for (int y = 0; y < gridResolution.y; y++)
            {
                // Calculate the position of the current grid cell
                Vector2 position = new Vector2(stepX * x + stepX / 2, stepY * y + stepY / 2);

                // Convert the 2D grid cell position to a 3D world position
                Vector3 positionAtCameraView = mainCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, mainCamera.farClipPlane / 2));

                // Add the calculated position to the list of grid cells
                gridCells.Add(positionAtCameraView);
            }
        }
    }

    public Vector3 GetRandomSpawnPos(){
        var randomPos = gridCells.GetRandom();
        gridCells.Remove(randomPos);
        return randomPos;
    }
}