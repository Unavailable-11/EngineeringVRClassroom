using UnityEngine;


public class UnityCycleStagesOnTouch : MonoBehaviour
{
    [Tooltip("List of stage GameObjects to cycle through.")]
    public GameObject[] stages; // 5 stages expected

    [Tooltip("Name or tag of the object that triggers stage change (e.g. 'Knife').")]
    public string triggerObjectTag = "Knife";

    private int currentStageIndex = 0;

    void Start()
    {
        // Ensure only the first stage is active at start, disable others
        for (int i = 0; i < stages.Length; i++)
        {
            if (stages[i] != null)
                stages[i].SetActive(i == currentStageIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is the trigger object (knife)
        if (other.CompareTag(triggerObjectTag))
        {
            CycleStage();
        }
    }

    private void CycleStage()
    {
        if (stages == null || stages.Length == 0)
            return;

        // Disable current stage
        if (stages[currentStageIndex] != null)
            stages[currentStageIndex].SetActive(false);

        // Move to the next stage index if possible
        currentStageIndex++;

        // Clamp to max stages - stop cycling after last stage
        if (currentStageIndex >= stages.Length)
        {
            currentStageIndex = stages.Length - 1; // stays at last stage
            return;
        }

        // Enable the new stage
        if (stages[currentStageIndex] != null)
            stages[currentStageIndex].SetActive(true);
    }
}
