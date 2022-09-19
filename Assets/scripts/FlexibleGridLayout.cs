using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows; // wie viele reihen es am ende gibt
    public int columns; // wie viele zeilen es am ende gibt
    public Vector2 cellSize; // wie groß jede zelle sein kann
    public Vector2 spacing;
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrRt = Mathf.Sqrt(transform.childCount); // wurzel der anzuordnenden objekte
       
        // die wurzel aufgerunded ergibt die anzahl an reihen und spalten die benötigt werden um alles unterzubringen (squarely)
        rows = Mathf.CeilToInt(sqrRt);
        columns = Mathf.CeilToInt(sqrRt);

        // hier wird geschaut, wie viel platz insgesamt zur verfügung steht
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        // daraus wird dann hier errechnet, wie groß eine zelle sein kann, um ins grid zu passen
        float cellWidth = parentWidth / (float)columns - ((spacing.x / (float)columns) *2) - (padding.left / (float) columns) - (padding.right / (float) columns);
        float cellHeight = parentHeight / (float)rows - ((spacing.y / (float)rows) *2) -  (padding.top / (float) rows) - (padding.bottom / (float) rows);

        // set the cellSize Vector with the newfound information
        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        int columnCount = 0;
        int rowCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            // errechnet die "koordinaten" unserer objekte im Grid, also reihen und zeilennummer
            rowCount = i / columns; // weird typecasting but I guess it always rounds down, so this works when were starting to count both index and rows from 0)
            columnCount = i % columns; // again, since were counting from 0, this actually magically works

            var item = rectChildren[i]; //reference to child object

            // bestimmt die position des objectes im rect
            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.right;

            // plaziert das objekt an seinem passenden platz
            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 0, cellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }
}
