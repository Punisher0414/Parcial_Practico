using UnityEngine;

/// <summary>
/// Salvo que lo crea necesario, no debería modificar esta clase.
/// </summary>
public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private Target redTarget;

    [SerializeField]
    private Target yellowTarget;

    [SerializeField]
    private float spawnRate = 3F;

    [SerializeField]
    private float force;

    private void Start()
    {
        InvokeRepeating("SpawnTarget", 0F, spawnRate);
    }

    private void SpawnTarget()
    {
        if (redTarget != null && yellowTarget != null)
        {
            // Selecciona aleatoriamente la bala a disparar
            Target targetToSpawn =
                Random.Range(0, 2) > 0 ? redTarget : yellowTarget;

            Target cloneTarget =
                Instantiate(targetToSpawn, transform.position, transform.rotation);

            cloneTarget.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}