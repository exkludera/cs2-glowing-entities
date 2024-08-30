using CounterStrikeSharp.API.Core;

public class Config : BasePluginConfig
{
    public bool RemoveOnPress { get; set; } = false;
    public bool RemoveOnDamage { get; set; } = false;
    public Dictionary<string, GlowSettings> Entities { get; set; } = new()
    {
        { "func_button", new GlowSettings { Color = "255 255 255 255", Model = "models/props/de_dust/hr_dust/dust_soccerball/dust_soccer_ball001.vmdl", Range = 5000, RangeMin = 0, Team = "", GlowOnAim = true } },
        { "trigger_multiple", new GlowSettings { Color = "0 0 255 128", Range = 1000, RangeMin = 0, Team = "", GlowOnAim = false } }
    };
}

public class GlowSettings
{
    public string Color { get; set; } = "255 255 255 255";
    public string Model { get; set; } = "";
    public int Range { get; set; } = 5000;
    public int RangeMin { get; set; } = 0;
    public string Team { get; set; } = "";
    public bool GlowOnAim { get; set; } = false;
}