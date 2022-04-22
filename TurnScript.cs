using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnScript : MonoBehaviour
{
    
    private int turnNumber = 0;
    public Text energyText;
    private int energy = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        Debug.Log("Starting TurnScript");
        incrementTurn();
        Debug.Log("Starting turn " + turnNumber.ToString());
    }

    public void EndTurn()
    {
        Debug.Log("Ending turn " + turnNumber.ToString());
        incrementTurn();
    }

    private void incrementTurn()
    {
        turnNumber += 1;
        Debug.Log("Entering Turn " + turnNumber.ToString());
        AddEnergy(turnNumber);
        Debug.Log("Energy count: " + energy.ToString());
        Debug.Log("Energy text: " + energyText.text);
    }

    public void AddEnergy(int number)
    {
        energy += number;
        energyText.text = energy.ToString();
    }
}
