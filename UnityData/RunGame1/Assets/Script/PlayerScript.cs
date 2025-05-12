using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.0f;

    int jumpCount;
    public float jumpPower = 5.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        //ジャンプのコードを書き変える
        if (Input.GetKeyDown("space") == true && jumpCount < 2)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面に当たった時にjumpCountを0に戻す
        if (collision.gameObject.tag == "Floor")
        {
            jumpCount = 0;
            Debug.Log(jumpCount);
        }

        if (collision.gameObject.tag == "Blocker")
        {
            FadeManager.Instance.LoadScene("GameOver", 3.0f);
        }
    }
}
