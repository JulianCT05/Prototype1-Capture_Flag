using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraShake.instance.StartCoroutine(CameraShake.instance.Shake());
            Destroy(collision.gameObject);
            
        }

        Debug.Log(collision.gameObject);

    }
}
