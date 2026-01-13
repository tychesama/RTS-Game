using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;

    public Material idleStateMaterial;
    public Material followStateMaterial;
    public Material attackStateMaterial;

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
}
