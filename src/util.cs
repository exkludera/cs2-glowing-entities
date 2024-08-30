using System.Drawing;

public class Util
{
    static public int GetAllowedTeam(string team)
    {
        team = team.ToLower();

        if (team == "t" || team == "terrorist")
            return 2;

        if (team == "ct" || team == "counterterrorist")
            return 3;

        return -1;
    }

    static public Color ParseColor(string colorValue)
    {
        var colorParts = colorValue.Split(' ');
        if (colorParts.Length == 4 &&
            int.TryParse(colorParts[0], out var r) &&
            int.TryParse(colorParts[1], out var g) &&
            int.TryParse(colorParts[2], out var b) &&
            int.TryParse(colorParts[3], out var a))
        {
            return Color.FromArgb(a, r, g, b);
        }

        return Color.FromArgb(255, 255, 255, 255);
    }
}
