using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float radius;
    public LayerMask layerMask;

    public bool Cast(Vector3 distance)
    {
        var pos = transform.position - distance;
        RaycastHit hit;
        if (Physics.SphereCast(pos, radius, distance,  out hit, distance.magnitude * 2f, layerMask, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}