using UnityEngine;

public class Jetpack : MonoBehaviour
{

    public void Detach()
    {
        transform.SetParent(null);

        var body = gameObject.AddComponent<Rigidbody>();
        body.angularVelocity = Random.insideUnitSphere * 10f;
        body.AddForce(Random.insideUnitSphere * 1f);
    }

    public void Attach(Transform jetpackContainer)
    {
        transform.parent = jetpackContainer;
        transform.localPosition = Vector3.zero;
    }
}
