using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : Entity
{
    public TabGroup tabGroup;
    public Image background;

    private void Start() 
    {
        cords = Utilities.ConvertCordsToInt(transform.position);
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    public override void MouseEnter(Vector3Int cords, List<Vector3Int> shape)
    {
        base.MouseEnter(cords, shape);
    }

    public override void MouseExit(Vector3Int cords, List<Vector3Int> shape)
    {
        base.MouseExit(cords, shape);
    }

    public override void MouseInteractionLeft(Vector3Int cords)
    {
        base.MouseInteractionLeft(cords);
    }

}
