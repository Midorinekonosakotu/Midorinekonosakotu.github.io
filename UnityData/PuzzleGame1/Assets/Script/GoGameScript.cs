using UnityEngine;
using UnityEngine.Tilemaps;

public class GoGameScript : MonoBehaviour
{
    [Header("Tilemap関連")]
    // 対象のTilemapオブジェクト（インスペクターから設定）
    public Tilemap tilemap;

    [Header("比較対象のオブジェクト")]
    // 比較したいオブジェクト（Collider2Dを持つ必要がある）
    public Tilemap objectToCompare;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetTilePixelSize();
        }
    }

    void GetTilePixelSize()
    {
        // 比較対象オブジェクトのColliderからサイズを取得
        Collider2D objectCollider = objectToCompare.GetComponent<Collider2D>();
        if (objectCollider == null)
        {
            Debug.LogError("比較対象のオブジェクトにCollider2Dコンポーネントがありません。");
            return;
        }
        Bounds objectBounds = objectCollider.bounds;
        //Debug.Log("オブジェクトのサイズ: " + objectBounds.size);

        // Tilemapのセルサイズを利用したサイズ比較（セル単位の大きさとして）
        Vector3 cellSize = tilemap.cellSize;

        
        float objectWidthInCells = objectBounds.size.x / cellSize.x;
        float objectHeightInCells = objectBounds.size.y / cellSize.y;
        Debug.Log("オブジェクトはTilemap上で幅 " + objectWidthInCells + " セル、高さ " + objectHeightInCells + " セル分です。");
    }
}
