using System.Collections;
using UnityEngine;

public class ExpandAndShowTooltip : MonoBehaviour
{
    [System.Serializable]
    public class ComponentData
    {
        public GameObject component;
        public GameObject tooltip;
        public float waitTime = 6f;
        public float expandFactor = 3f;
        public float tooltipDuration = 3f;
        public bool repeat = true;

        [HideInInspector]
        public Vector3 originalScale;
    }

    public ComponentData[] components;

    private int currentComponentIndex;

    void Start()
    {
        // Store the original scale for each component
        foreach (ComponentData componentData in components)
        {
            componentData.originalScale = componentData.component.transform.localScale;
        }

        // Start the routine for the first component
        StartCoroutine(ExpandAndShowTooltipRoutine());
    }

    IEnumerator ExpandAndShowTooltipRoutine()
    {
        // Repeat the process for each component
        while (currentComponentIndex < components.Length)
        {
            ComponentData componentData = components[currentComponentIndex];

            yield return new WaitForSeconds(componentData.waitTime);

            componentData.component.transform.localScale *= componentData.expandFactor;
            componentData.tooltip.SetActive(true);

            yield return new WaitForSeconds(componentData.tooltipDuration);

            componentData.component.transform.localScale = componentData.originalScale;
            componentData.tooltip.SetActive(false);

            // Move to the next component
            currentComponentIndex++;

            // Repeat the process for the first component if all components have been processed
            if (currentComponentIndex >= components.Length && components[0].repeat)
            {
                currentComponentIndex = 0;
            }
        }
    }
}




    

