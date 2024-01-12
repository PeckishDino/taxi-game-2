using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermediate : MonoBehaviour
{
    public PickUp[] pickUpPoints;
    public DropOff[] dropOffPoints;
    public Arrow arrow;
    public ScoreManager timer;

    void Start()
    {
        PopulateArrays();
        DeactivateObjects();
        ChoosePickUp();
    }


    void PopulateArrays()
    {
        pickUpPoints = FindObjectsOfType<PickUp>();
        dropOffPoints = FindObjectsOfType<DropOff>();
    }

    void DeactivateObjects()
    {
        foreach(PickUp p in pickUpPoints)
        {
            p.gameObject.SetActive(false);
        }

        foreach(DropOff d in dropOffPoints)
        {
            d.gameObject.SetActive(false);
        }
    }

    public void ChoosePickUp()
    {
        timer.ToggleTimer();
        int rand = Random.Range(0, pickUpPoints.Length);
        pickUpPoints[rand].gameObject.SetActive(true);
        arrow.transform.position = pickUpPoints[rand].gameObject.transform.position + arrow.positionOffset;
    }

    public void ChooseDropOff()
    {
        timer.ToggleTimer();
        int rand = Random.Range(0, dropOffPoints.Length);
        dropOffPoints[rand].gameObject.SetActive(true);
        arrow.transform.position = dropOffPoints[rand].gameObject.transform.position + arrow.positionOffset;
    }


}
