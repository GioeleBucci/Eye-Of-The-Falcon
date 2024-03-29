using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/**
 This class models an object that keeps track of the last selected GameObject. 
 When a second click occurs, it checks wether a suitable position was clicked
 and creates a vector that the selected entity tries to follow.
 */
public class ClickManager : MonoBehaviour
{
    // for now movement vector should not be used, since the click manager might have to deal with
    // different entities.
    [SerializeField] Vector2 _movementVector;
    [SerializeField] IClickable selectedEntity;
    [SerializeField] bool isAnEntitySelected;
    [SerializeField] Transform clickedEntityTransform;
    public Vector2 MovementVector { get { return this._movementVector; } }

    public IClickable GetSelectedEnetity() => this.selectedEntity;

    public void Notify(IClickable clickedEntity)
    {
        if (this.isAnEntitySelected && this.selectedEntity.Equals(clickedEntity))
        {
            Debug.Log("Deselected entity: " + clickedEntity);
            this.Deselect().OnDeselection();
            return;
        }
        Debug.Log("Clicked at position: " + clickedEntity.GetTransform().position + ", clickedEntity.Type = " + clickedEntity.GetType());
        this.selectedEntity = clickedEntity;
        this.isAnEntitySelected = true;
        this.clickedEntityTransform = clickedEntity.GetTransform();
        clickedEntity.OnSelection();
    }

    private IClickable Deselect()
    {
        if (this.isAnEntitySelected)
        {
            this.isAnEntitySelected = false;
        }
        IClickable entity = this.selectedEntity;
        this.selectedEntity = null;
        return entity;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.isAnEntitySelected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
