using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;

    public Material idleStateMaterial;
    public Material followStateMaterial;
    public Material attackStateMaterial;

    public int unitDamage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy") && targetToAttack != null)
        {
            targetToAttack = null;
        }
    }

    public void setIdleMaterial()
    {
        GetComponent<Renderer>().material = idleStateMaterial;
    }

    public void setFollowMaterial()
    {
        GetComponent<Renderer>().material = followStateMaterial;
    }

    public void setAttackMaterial()
    {
        GetComponent<Renderer>().material = attackStateMaterial;
    }

    private void OnDrawGizmos()
    {
        // follow distance
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,15f*0.25f);


        // should be the same with the other parameters

        // attack distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
        // stop attack distance
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,1.2f);
    }
}
