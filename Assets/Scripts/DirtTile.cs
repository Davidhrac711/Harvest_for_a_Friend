using UnityEngine;

public class DirtTile : MonoBehaviour
{
    public GameObject seedPrefab;  
    public GameObject grownPrefab;
    public GameObject coinPrefab;

    private GameObject currentPlant;
    private int state = 0; // 0 = prazdno, 1 = zasazeno (seminka), 2 = vyrostlo

    public void OnMouseDown()
    {
        if (state == 0)
        {
            currentPlant = Instantiate(seedPrefab, transform.position, Quaternion.identity);
            state = 1;

            Invoke("GrowPlant", 5f);
        }
        else if (state == 2)
        {
            Destroy(currentPlant); 
            state = 0;

            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        else if (state == 1)
        {
            Debug.Log("Ještì to nevyrostlo, musíš poèkat!");
        }
    }

    public void GrowPlant()
    {
        if (state == 1)
        {
            Destroy(currentPlant);
            currentPlant = Instantiate(grownPrefab, transform.position, Quaternion.identity);
            state = 2; //novy den
        }
    }
}
