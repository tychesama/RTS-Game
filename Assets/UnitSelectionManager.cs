using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance { get; set; }

    public List<GameObject> allUnitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    public LayerMask clickable;
    public LayerMask ground;
    public GameObject groundMarker;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Awake(){
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update(){
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            // check for selectable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)){
                if (Keyboard.current.leftShiftKey.isPressed){
                    MultiSelect(hit.collider.gameObject);
                } else {
                    Selection(hit.collider.gameObject); //SelectByClicking();
                }
            }
            else{
                if (!Keyboard.current.leftShiftKey.isPressed){
                    DeselectAll();
                }
            }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame && unitsSelected.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            // check for selectable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)){
                groundMarker.transform.position = hit.point;

                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }
    }

private void MultiSelect(GameObject unit){
    if (unitsSelected.Contains(unit) == false) {
        unitsSelected.Add(unit);
        EnableUnitMovement(unit, true);
        TriggerSelectionIndicator(unit, true);
    }
    else {
        unitsSelected.Remove(unit);
        EnableUnitMovement(unit, false);
        TriggerSelectionIndicator(unit, false);
    }
}
    
private void DeselectAll()
{
    foreach (var unit in unitsSelected) {
        EnableUnitMovement(unit, false);
        TriggerSelectionIndicator(unit, false);
    }

    groundMarker.SetActive(false);

    unitsSelected.Clear();
}

private void Selection(GameObject unit)
{
    DeselectAll();

    unitsSelected.Add(unit); 
    
    TriggerSelectionIndicator(unit, true);
    EnableUnitMovement(unit, true);
}

private void EnableUnitMovement(GameObject unit, bool shouldMove)
{
    unit.GetComponent<UnitMovement>().enabled = shouldMove;
}

private void TriggerSelectionIndicator(GameObject unit, bool isVisible){
    unit.transform.GetChild(0).gameObject.SetActive(isVisible);
}

}
