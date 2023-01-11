using UnityEngine;

/// <summary>
/// This class handles the raycast state. When it hover, select, enter and exit.
/// </summary>
public class Hover : MonoBehaviour
{
    Part previousHover;
    Part currentHover;
    Transform currentHitTransform;

    void Update()
    {
        // Hover objects.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            currentHitTransform = hit.transform;
            // Check if object has Part script.
            if (currentHitTransform != null)
            {
                bool isPart = currentHitTransform.TryGetComponent(out Part part);
                if (isPart)
                {
                    currentHover = part;
                }
            }
        }
        else
        {
            currentHover = null;
        }

        // ENTER HOVER, EXIT HOVER

        // No collisions on this frame, but one collision last frame
        if (currentHover == null)
        {
            if (previousHover != null)
            {
                previousHover.ExitHover();
            }
        }

        // The object is the same as last frame
        else if (previousHover == currentHover)
        {
            // Hover stays.
        }

        // The object is different than last frame.
        else if (previousHover != null) // and currentHovered != previousHovered
        {
            currentHover.EnterHover();
            previousHover.ExitHover();
        }

        // No object hit last frame. PreviousHover is null, currentHover != null.
        else
        {
            currentHover.EnterHover();
        }

        previousHover = currentHover;
    }

    public Part GetHighlightedPart()
    {
        return currentHover;
    }
}
