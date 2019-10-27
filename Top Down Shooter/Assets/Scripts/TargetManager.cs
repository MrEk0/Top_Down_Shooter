using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] Text scoreText = null;

    float startScore = 0f;

    List<GameObject> targets;

    private void Awake()
    {
        targets = new List<GameObject>();
    }

    public void AddTarget(GameObject target)
    {
        targets.Add(target);
        target.GetComponent<Target>().OnDestroyed += IncreaseScore;
        target.GetComponent<Target>().OnRemoved += RemoveTarget;//!!!!!
    }

    private void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
    }

    private void IncreaseScore(float points)
    {
        startScore += points;
        scoreText.text = "Score  " + startScore.ToString();
    }

    public int GetTargetNumber()
    {
        return targets.Count;
    }
}
