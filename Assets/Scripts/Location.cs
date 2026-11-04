using UnityEngine;
using System.Collections.Generic;

public class Location : MonoBehaviour
{
    public List<Location> connectedLocations = new List<Location>();

    public bool isCity;

    public bool hasGivenStamp = false;

    public int region = 1; //added

    public bool givesPassport = false; //added

    public bool isCenterHub = false; //added
}
