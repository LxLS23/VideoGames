using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    public float speed = 20f;

    public float timer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
        
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            gameObject.SetActive(false);
            timer = 0f;
        }
    }
}
