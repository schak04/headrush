using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float size = 10f;
    public Color color = Color.green;

    void OnGUI()
    {
        // calc center of screen
        float xMin = (Screen.width / 2) - (size / 2);
        float yMin = (Screen.height / 2) - (size / 2);

        // crosshair style
        GUIStyle style = new GUIStyle();
        style.normal.background = Texture2D.whiteTexture;
        
        // save current color & set new one
        Color oldColor = GUI.color;
        GUI.color = color;

        // draw horizontal & vertical lines
        GUI.DrawTexture(new Rect(xMin, (Screen.height / 2) - 1, size, 2), Texture2D.whiteTexture);
        GUI.DrawTexture(new Rect((Screen.width / 2) - 1, yMin, 2, size), Texture2D.whiteTexture);

        // restore color
        GUI.color = oldColor;
    }
}
