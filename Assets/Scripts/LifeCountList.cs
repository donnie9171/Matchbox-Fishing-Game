using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LifeCountList : MonoBehaviour
{
    [SerializeField] private GameObject imageprefab;
    private List<GameObject> image = new List<GameObject>();

    public void PopulateUIList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newImage = Instantiate(imageprefab, transform);
            newImage.name = "LifeImage_" + i;
            newImage.SetActive(false); // Initially disable the image
            image.Add(newImage); // Add the instantiated GameObject to the list
        }
    }

    public void SetLifeCount(int count, int maxCount)
    {
        for (int i = 0; i < image.Count; i++)
        {
            if (i < count && i < maxCount)
            {
                image[i].SetActive(true);
            }
            else
            {
                image[i].SetActive(false);
            }
        }
    }
}
