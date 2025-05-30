using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CubeMoveScript : MonoBehaviour
{
    // マウスで掴んだゲームオブジェクトの中心座標と、マウスカーソルの座標の差分を格納する変数
    private Vector3 offset;
    [SerializeField] private Vector3 puzzleObjPos1;
    [SerializeField] private Vector3 puzzleObjPos2;
    [SerializeField] private Vector3 puzzleObjPos3;
    private bool cubeMove = true;

    private void Update()
    {
        
    }

    // マウスでゲームオブジェクトをクリックしたときに呼び出されるメソッドです。offset変数に、マウスカーソルとゲームオブジェクトの中心座標の差分を格納します。
    void OnMouseDown()
    {
        if(cubeMove)
        {
            offset = gameObject.transform.position - GetMouseWorldPos();
        }
    }

    // マウスでゲームオブジェクトをドラッグしているときに呼び出されるメソッドです。GetMouseWorldPos()メソッドを使ってマウスカーソルの座標をワールド座標に変換し、offset変数を足してゲームオブジェクトを移動させます。
    void OnMouseDrag()
    {
        if(cubeMove)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    // マウスカーソルの座標をスクリーン座標からワールド座標に変換するメソッドです。Input.mousePositionでスクリーン座標を取得し、Camera.main.ScreenToWorldPoint(mousePos)でワールド座標に変換して返します。
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}