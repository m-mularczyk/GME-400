using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private int _rotationStep = 10;
    [SerializeField] private GameObject _cannonProjectilePrefab;
    [SerializeField] private Transform _cannonProjectileSpawnPoint;
    [SerializeField] private float _cannonForce = 50f;


    public void RotateCannon(int value)
    {
        /*
        Vector3 currentRot = transform.rotation.eulerAngles;
        Vector3 newRotation = new Vector3(currentRot.x, currentRot.y + (value * _rotationStep), currentRot.z);
        transform.rotation = Quaternion.Euler(newRotation);
        Debug.Log("Rotation");
        */

        transform.Rotate(new Vector3(0, _rotationStep * value, 0));
    }

    public void FireCannon()
    {
        Debug.Log("Fire!");
        GameObject cannonBall = Instantiate(_cannonProjectilePrefab, _cannonProjectileSpawnPoint.position, _cannonProjectileSpawnPoint.rotation);
        cannonBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _cannonForce, ForceMode.Impulse);
    }
}


