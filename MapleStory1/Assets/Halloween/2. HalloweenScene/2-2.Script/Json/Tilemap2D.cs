using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

public class Tilemap2D : MonoBehaviour
{
    [Header("Tile")]
    [SerializeField]
    private GameObject tilePrefab;
    public void GenerateTilemap(string mapData)
    {
        int width = 20;
        int height = 30;
        int index = 0;
        string strReturnData = mapData;
        JObject root = JObject.Parse(strReturnData);
        JToken arr_data = root["Tiles"];
        JArray Tile_array = (JArray)arr_data;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for(index = 0; index < arr_data.Count(); index++)
                {
                    if(Convert.ToInt32(Tile_array[index]["X"]) == x && Convert.ToInt32(Tile_array[index]["Y"]) == y)
                    {
                        Vector3 position = new Vector3(-(width * 0.5f + 0.5f) + (x * 0.5f), (height * 0.5f - 0.5f) - (y * 0.5f), 4);

                        SpawnTile((TileName)Enum.Parse(typeof(TileName),Tile_array[index]["TileNum"].ToString()), position);
                    }
                }
            }
        }
    }

    private void SpawnTile(TileName tilename, Vector3 position)
    {
        GameObject myTile = Instantiate(tilePrefab, position, Quaternion.identity);

        myTile.name = "Tile"; // Tile ������Ʈ�� �̸��� "Tile"�� ����
        myTile.transform.SetParent(transform); // Tilemap2D ������Ʈ�� Tile ������Ʈ�� �θ�� ����

        Tile tile = myTile.GetComponent<Tile>();
        tile.Setup(tilename);
    }
}

// ���� ���·� ��ġ�� Ÿ�ϵ��� ���� ��ܺ��� ���������� ��ȣ�� �ο�
// 0, 1, 2, 3, 4, 5, 6, 7, 8,...
// 6, 7.....
/*
int index = y * width + x;

if (mapData.mapData[index] == (int)TileName.Empty)
{
    continue;
}

// �����Ǵ� Ÿ�ϸ��� �߾��� (0, 0, 0)�� ��ġ
Vector3 position = new Vector3(-(width * 0.5f - 0.5f) + x, (height * 0.5f - 0.5f) - y);

// ���� index�� �� ������ TileName.Empty(0)���� ũ��, TileName.LastIndex(17)���� ������
if (mapData.mapData[index] > (int)TileName.Empty && mapData.mapData[index] < (int)TileName.LastIndex)
{
    // Ÿ�� ����
    SpawnTile((TileName)mapData.mapData[index], position);
}
*/
