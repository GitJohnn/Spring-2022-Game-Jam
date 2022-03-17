using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectPosition : MonoBehaviour
{
    RectTransform scrollRectTransform;
    RectTransform contentPanel;
    RectTransform selectedRectTransform;
    GameObject lastSelected;

    float contentHeight;
    MusicSelectionPlayer musicPlayer;
    List<MusicLibrary> songSelection = new List<MusicLibrary>();

    void Awake()
    {
        scrollRectTransform = GetComponent<RectTransform>();
        contentPanel = GetComponent<ScrollRect>().content;
        musicPlayer = GetComponent<MusicSelectionPlayer>();
        contentHeight = contentPanel.GetChild(0).GetComponent<RectTransform>().rect.height;
        Debug.Log(contentPanel.childCount);
        for(int i = 0; i < contentPanel.childCount; i++)
        {
            SongSelected songObj = contentPanel.GetChild(i).GetComponent<SongSelected>();
            songSelection.Add(songObj.MusicObject);
        }
        musicPlayer.SetSongSelection(songSelection);
    }

    void Update()
    {
        // Get the currently selected UI element from the event system.
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(selected.name);
        // Return if there are none.
        if (selected == null)
        {
            return;
        }
        // Return if the selected game object is not inside the scroll rect.
        if (selected.transform.parent != contentPanel.transform)
        {
            return;
        }
        // Return if the selected game object is the same as it was last frame,
        // meaning we haven't moved.
        if (selected == lastSelected)
        {
            return;
        }

        int childIndex = selected.transform.GetSiblingIndex();
        Debug.Log(childIndex);
        musicPlayer.SetSongIndex(childIndex);
        float scrollPos =  childIndex * contentHeight;

        contentPanel.localPosition = new Vector2(contentPanel.localPosition.x, scrollPos);

        //// Get the rect tranform for the selected game object.
        //selectedRectTransform = selected.GetComponent<RectTransform>();
        //// The position of the selected UI element is the absolute anchor position,
        //// ie. the local position within the scroll rect + its height if we're
        //// scrolling down. If we're scrolling up it's just the absolute anchor position.
        //float selectedPositionY = Mathf.Abs(selectedRectTransform.anchoredPosition.y) + selectedRectTransform.rect.height;

        //// The upper bound of the scroll view is the anchor position of the content we're scrolling.
        //float scrollViewMinY = contentPanel.anchoredPosition.y;
        //// The lower bound is the anchor position + the height of the scroll rect.
        //float scrollViewMaxY = contentPanel.anchoredPosition.y + scrollRectTransform.rect.height;

        //// If the selected position is below the current lower bound of the scroll view we scroll down.
        //if (selectedPositionY > scrollViewMaxY)
        //{
        //    float newY = selectedPositionY - scrollRectTransform.rect.height;
        //    contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, newY);
        //}
        //// If the selected position is above the current upper bound of the scroll view we scroll up.
        //else if (Mathf.Abs(selectedRectTransform.anchoredPosition.y) < scrollViewMinY)
        //{
        //    contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, Mathf.Abs(selectedRectTransform.anchoredPosition.y));
        //}

        lastSelected = selected;
    }
}
