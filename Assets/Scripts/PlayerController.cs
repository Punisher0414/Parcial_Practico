using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]

    /// <summary>
    /// Velocidad a la que se mueve el personaje
    /// </summary>
    [SerializeField]
    private float movementSpeed = 10F;

    [Header("Shoot")]

    /// <summary>
    /// Fuerza a la que se dispara la bala
    /// </summary>
    [SerializeField]
    private float bulletForce;

    /// <summary>
    /// Tiempo que demora el jugador sin poder disparar después de un disparo efectivo
    /// </summary>
    [SerializeField]
    private float shootCooldown;

    /// <summary>
    /// El punto en el que se instancia la bala
    /// </summary>
    [SerializeField]
    private Transform bulletSpawnPosition;

    [Header("Bullet Prefabs")]

    /// <summary>
    /// Prefab del primer tipo de bala
    /// </summary>
    [SerializeField]
    private GameObject redBulletGO;

    /// <summary>
    /// Prefab del segundo tipo de bala
    /// </summary>
    [SerializeField]
    private GameObject yellowBulletGO;

    /// <summary>
    /// Bala seleccionada para disparar
    /// </summary>
    private GameObject selectedBullet;

    private bool canShoot = true;
    [SerializeField]
    private bool yellowBullet = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            yellowBullet = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            yellowBullet = true;
        }

        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = false;
            Invoke("ResetCanShoot", shootCooldown);
            Shoot(yellowBullet);
        }

      

        float horizontalMovement = Input.GetAxis("Mouse X");

        if (horizontalMovement != 0)
        {
            transform.Translate(transform.right * horizontalMovement * movementSpeed * Time.deltaTime);
        }
    }

    private void RedBulletShoot()
    {
        GameObject redBulletClone = Instantiate(redBulletGO, bulletSpawnPosition.position, bulletSpawnPosition.rotation);

        Rigidbody redBulletRB = redBulletClone.GetComponent<Rigidbody>();

        if (redBulletRB != null)
        {
            redBulletRB.AddForce(redBulletClone.transform.forward * bulletForce, ForceMode.Impulse);
        }

    }

    private void Shoot(bool yBullet)
    {
        if (yBullet == true)
        {
            GameObject yb = Instantiate(yellowBulletGO, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            Rigidbody ybRb = yb.GetComponent<Rigidbody>();
            ybRb.AddForce(yb.transform.forward * bulletForce, ForceMode.Impulse);
        }
        else {
            GameObject rb = Instantiate(redBulletGO, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            Rigidbody rbRb = rb.GetComponent<Rigidbody>();
            rbRb.AddForce(rb.transform.forward * bulletForce, ForceMode.Impulse);
        }

    }
    private void ResetCanShoot()
    {
        canShoot = true;
    }
}