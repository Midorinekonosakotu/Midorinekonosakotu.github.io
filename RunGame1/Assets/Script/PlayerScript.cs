using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.0f;

    int jumpCount;
    public float jumpPower = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        //ジャンプのコードを書き変える
        if (Input.GetKeyDown("space") == true && jumpCount < 1)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面に当たった時にjumpCountを0に戻す
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            Debug.Log(jumpCount);
        }
    }
}
