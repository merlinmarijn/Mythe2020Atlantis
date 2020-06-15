using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingPuzzle : MonoBehaviour
{
    //3x3 Sliding Puzzle Test Code
    public List<GameObject> Tiles;
    public float Size = 3;
    [HideInInspector]
    public List<Vector3> WinPosition;
    private float minPos = -0.33f;
    private float maxPos = 0.33f;
    private GameObject CurrentTile;
    private bool Breaknow;
    private float TileSize;
    private bool canStart = false;
    public int TileScale = 100;
    public UnityEvent CompletedPuzzle = new UnityEvent();


    private void Start()
    {
        TileSize = 1 / Size;
        maxPos = (((Size - 1) / 2) * TileSize);
        minPos = -(((Size - 1) / 2) * TileSize);
        for (int i = 0; i < (Size * Size)-1; i++)
        {
            float x = (i % Size) * TileSize;
            float z = (Mathf.Floor(i / Size)) * TileSize;
            Tiles[i].transform.localPosition = new Vector3(x+minPos, 1, z+minPos);
        }
        foreach(GameObject item in Tiles)
        {
            WinPosition.Add(item.transform.localPosition);
        }
        ResizeTiles();
        Shamble();
        canStart = true;
    }

    public void MoveTile(GameObject tile)
    {
        CurrentTile = tile;
        CheckInBound(tile);
        if (canStart)
        {
            CheckWinstate();
        }
    }

    private void CheckInBound(GameObject obj)
    {
        float X = obj.transform.localPosition.x;
        float z = obj.transform.localPosition.z;
        //check upwards direction
        if (X+TileSize <= maxPos)
        {
            CheckAdjacentTiles(obj.transform.localPosition + new Vector3(TileSize, 0,0));
        }
        //check down direction
        if(X-TileSize >= minPos)
        {
            if (!Breaknow)
            {
                CheckAdjacentTiles(obj.transform.localPosition + new Vector3(-TileSize, 0, 0));
            }
        }
        //check left direction
        if (z + TileSize <= maxPos)
        {
            if (!Breaknow)
            {
                CheckAdjacentTiles(obj.transform.localPosition + new Vector3(0, 0, TileSize));
            }
        }
        //check right direction
        if (z-TileSize >= minPos)
        {
            if (!Breaknow)
            {
                CheckAdjacentTiles(obj.transform.localPosition + new Vector3(0, 0, -TileSize));
            }
        }
        Breaknow = false;
    }

    private void CheckAdjacentTiles(Vector3 vec)
    {
        bool isOccupied = false;
        foreach(GameObject item in Tiles)
        {
            if(item.transform.localPosition == vec)
            {
                isOccupied = true;
            }
        }
        if(isOccupied == false)
        {
            Breaknow = true;
            CurrentTile.transform.localPosition = vec;
        }
    }

    private void ResizeTiles()
    {
        foreach(GameObject item in Tiles)
        {
            item.transform.localScale = new Vector3(TileSize * TileScale, 0.5f, TileSize * TileScale);
        }
    }

    private void Shamble()
    {
        for (int i = 0; i < 100; i++)
        {
            foreach(GameObject item in Tiles)
            {
                MoveTile(item);
            }
        }
        canStart = true;
    }
    private void CheckWinstate()
    {
        int wincount=0;
        for(int i = 0; i < Tiles.Count; i++)
        {
            if(Tiles[i].transform.localPosition == new Vector3(WinPosition[i].x, WinPosition[i].y, WinPosition[i].z))
            {
                wincount++;
            }
        }
        Debug.Log(wincount);
        if (wincount == Tiles.Count)
        {
            CompletedPuzzle.Invoke();
        }
    }
}
