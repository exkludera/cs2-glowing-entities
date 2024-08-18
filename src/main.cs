using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using static CounterStrikeSharp.API.Core.Listeners;
using System.Drawing;

namespace GlowingButtons;

public class Config : BasePluginConfig
{
    public string Color { get; set; } = "255 255 255 128";
    public string Model { get; set; } = "models/props/de_dust/hr_dust/dust_soccerball/dust_soccer_ball001.vmdl";
    public int Range { get; set; } = 5000;
    public int RangeMin { get; set; } = 0;
    public string Team { get; set; } = "";
    public bool GlowOnAim { get; set; } = false;
    public bool RemoveOnPress { get; set; } = true;
}

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Glowing Buttons";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "exkludera";

    public Dictionary<CEntityInstance, CEntityInstance> glowEntities = new Dictionary<CEntityInstance, CEntityInstance>();
    public int allowedTeam;
    public int glowType;

    public override void Load(bool hotReload)
    {
        RegisterListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        RegisterEventHandler<EventRoundStart>(EventRoundStart);
        HookEntityOutput("func_button", "OnPressed", (CEntityIOOutput output, string name, CEntityInstance activator, CEntityInstance caller, CVariant value, float delay) =>
        {
            if (caller != null && caller.IsValid)
            {
                if (Config.RemoveOnPress)
                {
                    caller.Remove();
                    glowEntities.Remove(caller);
                }
            }

            return HookResult.Continue;
        }, HookMode.Post);
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        DeregisterEventHandler<EventRoundStart>(EventRoundStart);
        UnhookEntityOutput("func_button", "OnPressed", (CEntityIOOutput output, string name, CEntityInstance activator, CEntityInstance caller, CVariant value, float delay) =>
        {
            if (caller != null && caller.IsValid)
            {
                if (Config.RemoveOnPress)
                {
                    caller.Remove();
                    glowEntities.Remove(caller);
                }
            }

            return HookResult.Continue;
        }, HookMode.Post);
    }

    public void OnServerPrecacheResources(ResourceManifest manifest)
    {
        manifest.AddResource(Config.Model);
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;

        string team = config.Team.ToLower();

        if (team == "t" || team == "terrorist")
            allowedTeam = 2;

        else if (team == "ct" || team == "counterterrorist")
            allowedTeam = 3;

        else allowedTeam = -1;

        glowType = Config.GlowOnAim ? 2 : 3;
    }

    HookResult EventRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        var buttons = Utilities.FindAllEntitiesByDesignerName<CPhysicalButton>("func_button")!;

        foreach (var button in buttons)
        {
            var modelGlow = Utilities.CreateEntityByName<CDynamicProp>("prop_dynamic")!;

            modelGlow.Spawnflags = 256;
            modelGlow.Render = Color.Transparent;

            modelGlow.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags = (uint)(modelGlow.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags & ~(1 << 2));

            modelGlow.SetModel(Config.Model);
            modelGlow.DispatchSpawn();

            modelGlow.Glow.GlowColorOverride = ParseColor(Config.Color);
            modelGlow.Glow.GlowRange = Config.Range;
            modelGlow.Glow.GlowRangeMin = Config.RangeMin;
            modelGlow.Glow.GlowTeam = allowedTeam;
            modelGlow.Glow.GlowType = glowType;

            modelGlow.Teleport(button.AbsOrigin, button.AbsRotation, button.AbsVelocity);
            modelGlow.AcceptInput("SetParent", button, modelGlow, "!activator");

            glowEntities.Add(button, modelGlow);
        }

        return HookResult.Continue;
    }

    private Color ParseColor(string colorValue)
    {
        var colorParts = colorValue.Split(',');
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