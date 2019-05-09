using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private List<Vector3> newVertices = new List<Vector3>();
    private List<int> newTriangles = new List<int>();
    private List<Vector2> newUV = new List<Vector2>();

    private float tUnit = 0.125f;
    private Vector2 tStone = new Vector2(1, 0);
    private Vector2 tSand = new Vector2(3, 1);
    private Vector2 tGrass = new Vector2(0, 1);
    private Vector2 tGrassTop = new Vector2(1, 1);
    private Vector2 tWood = new Vector2(2, 0);
    private Vector2 tWoodSide = new Vector2(0, 0);
    private Vector2 tFire = new Vector2(4, 0);
    private Vector2 tWater = new Vector2(0, 7);
    private Vector2 tClay = new Vector2(5, 0);
    private Vector2 tMetal = new Vector2(6, 0);
    private Vector2 tBrick = new Vector2(7, 0);

    private Mesh mesh;
    private MeshCollider col;

    private int faceCount;

    public GameObject worldGO;
    private World world;

    public int chunkSize = 16;
    public int chunkX;
    public int chunkY;
    public int chunkZ;

    public bool update;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        col = GetComponent<MeshCollider>();
        world = worldGO.GetComponent("World") as World;
        GenerateMesh();
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = newVertices.ToArray();
        mesh.uv = newUV.ToArray();
        mesh.triangles = newTriangles.ToArray();
        //MeshUtility.Optimize(mesh);
        mesh.RecalculateNormals();

        col.sharedMesh = null;
        col.sharedMesh = mesh;

        newVertices.Clear();
        newUV.Clear();
        newTriangles.Clear();

        faceCount = 0;
    }
    void Cube(Vector2 texturePos)
    {
        newTriangles.Add(faceCount * 4); //1
        newTriangles.Add(faceCount * 4 + 1); //2
        newTriangles.Add(faceCount * 4 + 2); //3
        newTriangles.Add(faceCount * 4); //1
        newTriangles.Add(faceCount * 4 + 2); //3
        newTriangles.Add(faceCount * 4 + 3); //4

        newUV.Add(new Vector2(tUnit * texturePos.x + tUnit, tUnit * texturePos.y));
        newUV.Add(new Vector2(tUnit * texturePos.x + tUnit, tUnit * texturePos.y + tUnit));
        newUV.Add(new Vector2(tUnit * texturePos.x, tUnit * texturePos.y + tUnit));
        newUV.Add(new Vector2(tUnit * texturePos.x, tUnit * texturePos.y));

        faceCount++;
    }

    void CubeTop(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x, y, z));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrassTop;
                break;
            case 3:
                texturePos = tWood;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    void CubeNorth(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x, y - 1, z + 1));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrass;
                break;
            case 3:
                texturePos = tWoodSide;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    void CubeEast(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x + 1, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrass;
                break;
            case 3:
                texturePos = tWoodSide;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    void CubeSouth(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z));
        newVertices.Add(new Vector3(x, y, z));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrass;
                break;
            case 3:
                texturePos = tWoodSide;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    void CubeWest(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z + 1));
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x, y, z));
        newVertices.Add(new Vector3(x, y - 1, z));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrass;
                break;
            case 3:
                texturePos = tWoodSide;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    void CubeBottom(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));
        newVertices.Add(new Vector3(x, y - 1, z + 1));
        Vector2 texturePos = new Vector2(0, 0);

        switch (Block(x, y, z))
        {
            case 1:
                texturePos = tStone;
                break;
            case 2:
                texturePos = tGrass;
                break;
            case 3:
                texturePos = tWood;
                break;
            case 4:
                texturePos = tWater;
                break;
            case 5:
                texturePos = tSand;
                break;
            case 6:
                texturePos = tFire;
                break;
            case 7:
                texturePos = tClay;
                break;
            case 8:
                texturePos = tMetal;
                break;
            case 9:
                texturePos = tBrick;
                break;
        }

        Cube(texturePos);
    }
    public void GenerateMesh()
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int z = 0; z < chunkSize; z++)
                {
                    if (Block(x, y, z) != 0)
                    {
                        //block is solid


                        if (Block(x, y + 1, z) == 0)
                        {
                            //block above is air
                            CubeTop(x, y, z, Block(x, y, z));
                        }
                        if (Block(x, y - 1, z) == 0)
                        {
                            //block below is air
                            CubeBottom(x, y, z, Block(x, y, z));
                        }
                        if (Block(x + 1, y, z) == 0)
                        {
                            //block east is air
                            CubeEast(x, y, z, Block(x, y, z));
                        }
                        if (Block(x - 1, y, z) == 0)
                        {
                            //block west is air
                            CubeWest(x, y, z, Block(x, y, z));
                        }
                        if (Block(x, y, z + 1) == 0)
                        {
                            //block north is air
                            CubeNorth(x, y, z, Block(x, y, z));
                        }
                        if (Block(x, y, z - 1) == 0)
                        {
                            //block south is air
                            CubeSouth(x, y, z, Block(x, y, z));
                        }
                    }
                }
            }
        }
        UpdateMesh();
    }
    byte Block(int x, int y, int z)
    {
        return world.Block(x + chunkX, y + chunkY, z + chunkZ);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (update)
        {
            GenerateMesh();
            update = false;
        }
    }
}
