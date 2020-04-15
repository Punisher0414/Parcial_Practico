using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float autoDestroyTime;
    private void Start()
    {
        // Autodestrucción de la bala
        Invoke("Destroy", autoDestroyTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            Destroy(collision.gameObject);
        }
        Destroy();
    }



   
    private void Destroy()
    {
        Destroy(gameObject);
    }
}