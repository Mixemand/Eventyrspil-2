using UnityEngine;

public class mapGrid : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("General Grid")]
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridCellSize;
    [SerializeField] private float cellOffset;
    [SerializeField] private float leftOffset;

    [Header("Lawn mowers")]
    [SerializeField] private Color mowerColor;

    [SerializeField] private GameObject cellPrefab;

    private void Start()
    {
        float orthSize = cam.orthographicSize;

        float left = orthSize / (Screen.height / 2) * (Screen.width / 2);

        for(int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                Vector3 pos = new Vector3(i * gridCellSize, j * gridCellSize, 0);
                pos.x -= left - cellOffset - leftOffset;
                pos.y -= orthSize - cellOffset;
                GameObject spot = Instantiate(cellPrefab, pos, Quaternion.identity);

                if(i == 0)
                {
                    spot.GetComponent<SpriteRenderer>().color = mowerColor;
                    spot.tag = "Untagged";
                }
            }
        }
    }
}
