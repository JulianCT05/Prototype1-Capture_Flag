using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private SpriteRenderer sr;
    private bool isFlashing = false;
    private Coroutine flashCoroutine;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            Destroy(collision.gameObject);

            if (!isFlashing)
            {
                flashCoroutine = StartCoroutine(FlashContinuously());
            }
        }

        if (collision.gameObject.tag == "Yarea")
        {
            if (isFlashing)
            {
                StopCoroutine(flashCoroutine);
                isFlashing = false;
                sr.color = Color.white;
            }
        }
    }

    private System.Collections.IEnumerator FlashContinuously()
    {
        isFlashing = true;

        while (true)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
