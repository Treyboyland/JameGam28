using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static int Random(this Vector2Int vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }

    public static float Random(this Vector2 vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }

    public static T Random<T>(this List<T> list)
    {
        int chosenIndex = UnityEngine.Random.Range(0, list.Count);
        return list[chosenIndex];
    }

    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int chosen = UnityEngine.Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[chosen];
            list[chosen] = temp;
        }
    }

    public static List<Vector2Int> GetPoints(this Vector2Int dimensions)
    {
        List<Vector2Int> toReturn = new List<Vector2Int>(dimensions.x * dimensions.y);
        for (int x = 0; x < dimensions.x; x++)
        {
            for (int y = 0; y < dimensions.y; y++)
            {
                toReturn.Add(new Vector2Int(x, y));
            }
        }

        return toReturn;
    }

    public static int DiceRoll(int numberOfDice, int diceSides)
    {
        int total = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            total += UnityEngine.Random.Range(1, diceSides + 1);
        }

        return total;
    }

    public static int DiceRoll(string diceString)
    {
        string[] parts = diceString.Split('d', System.StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2)
        {
            bool countParsed = int.TryParse(parts[0], out int numberOfDice);
            bool sidesParsed = int.TryParse(parts[1], out int numberOfSides);
            
            if (countParsed && sidesParsed)
            {
                return DiceRoll(numberOfDice, numberOfSides);
            }
            else
            {
                Debug.LogWarning((countParsed ? "" : "Count \"" + parts[0] + "\" can't be parsed. ") +
                    (sidesParsed ? "" : "Sides \"" + parts[1] + "\" can't be parsed. "));
            }
        }
        return -1;
    }
}
