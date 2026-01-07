using UnityEngine;

public class Unit : MonoBehaviour
{
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
    }

    private void OnDestroy()
    {
        if (UnitSelectionManager.Instance != null)
            UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
    }

}
