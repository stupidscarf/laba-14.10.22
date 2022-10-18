using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPainting : MonoBehaviour
{
    [SerializeField] private Color _tileActiveColor;
    [SerializeField] private Color _tileDefaltColor;
    [SerializeField] private LayerMask _groundLayerMask;
    private GameObject currTriggerGO;
    private Color currColor;
    private bool isColored;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_groundLayerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            currTriggerGO = collision.gameObject;
            currTriggerGO.GetComponent<SpriteRenderer>().color = GetCurrentColor();
        }
    }
    private Color GetCurrentColor()
    {
        isColored = (currColor == _tileActiveColor);
        if (isColored)
        {
            isColored = false;
            return _tileDefaltColor;
        }
        isColored = true;
        return _tileActiveColor;
    }
}
