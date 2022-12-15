using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float defaultPositionX, defaultPositionY;

    private GameObject currentPosition;
    public GameObject CurrentPosition { get => currentPosition; set => SetPosition(value); }
    public string Name { get; set; }

    public void SetPosition(GameObject cellMap)
    {
        currentPosition = cellMap;
        gameObject.transform.position = new Vector3(cellMap.transform.position.x + defaultPositionX, cellMap.transform.position.y + defaultPositionY);
    }
}
