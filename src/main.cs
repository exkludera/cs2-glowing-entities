using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using static CounterStrikeSharp.API.Core.Listeners;
using System.Drawing;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Glowing Entities";
    public override string ModuleVersion => "1.1.0";
    public override string ModuleAuthor => "exkludera";

    public Dictionary<CEntityInstance, CEntityInstance> glowEntities = new Dictionary<CEntityInstance, CEntityInstance>();

    public override void Load(bool hotReload)
    {
        RegisterListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        RegisterEventHandler<EventRoundStart>(EventRoundStart);

        HookEntityOutput("*", "OnPressed", OnPressed, HookMode.Post);
        HookEntityOutput("*", "OnTakeDamage", OnTakeDamage, HookMode.Post);
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<OnServerPrecacheResources>(OnServerPrecacheResources);
        DeregisterEventHandler<EventRoundStart>(EventRoundStart);

        UnhookEntityOutput("*", "OnPressed", OnPressed, HookMode.Post);
        UnhookEntityOutput("*", "OnTakeDamage", OnTakeDamage, HookMode.Post);
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
    }

    public void OnServerPrecacheResources(ResourceManifest manifest)
    {
        foreach (var entity in Config.Entities)
            manifest.AddResource(entity.Value.Model);
    }

    HookResult EventRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        var entities = Utilities.GetAllEntities();

        foreach (var entityConfig in Config.Entities)
        {
            var entityName = entityConfig.Key;
            var settings = entityConfig.Value;

            foreach (var entity in entities)
            {
                if (entity.DesignerName.StartsWith(entityName))
                {
                    var cbaseentity = entity.As<CBaseEntity>();

                    var modelGlow = Utilities.CreateEntityByName<CDynamicProp>("prop_dynamic")!;

                    modelGlow.Spawnflags = 256;
                    modelGlow.Render = Color.Transparent;

                    modelGlow.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags = (uint)(modelGlow.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags & ~(1 << 2));

                    modelGlow.SetModel(!string.IsNullOrEmpty(settings.Model) ? settings.Model : cbaseentity.CBodyComponent!.SceneNode!.GetSkeletonInstance().ModelState.ModelName);
                    modelGlow.DispatchSpawn();

                    modelGlow.Glow.GlowColorOverride = Util.ParseColor(settings.Color);
                    modelGlow.Glow.GlowRange = settings.Range;
                    modelGlow.Glow.GlowRangeMin = settings.RangeMin;
                    modelGlow.Glow.GlowTeam = Util.GetAllowedTeam(settings.Team);
                    modelGlow.Glow.GlowType = settings.GlowOnAim ? 2 : 3;

                    modelGlow.Teleport(cbaseentity.AbsOrigin, cbaseentity.AbsRotation, cbaseentity.AbsVelocity);
                    modelGlow.AcceptInput("SetParent", entity, modelGlow, "!activator");

                    glowEntities.Add(entity, modelGlow);
                }
            }
        }

        return HookResult.Continue;
    }

    private HookResult OnPressed(CEntityIOOutput output, string name, CEntityInstance activator, CEntityInstance caller, CVariant value, float delay)
    {
        if (Config.RemoveOnDamage)
        {
            if (glowEntities.TryGetValue(caller, out CEntityInstance? glow))
            {
                glow.Remove();
                glowEntities.Remove(caller);
            }
        }

        return HookResult.Continue;
    }

    private HookResult OnTakeDamage(CEntityIOOutput output, string name, CEntityInstance activator, CEntityInstance caller, CVariant value, float delay)
    {
        if (Config.RemoveOnDamage)
        {
            if (glowEntities.TryGetValue(caller, out CEntityInstance? glow))
            {
                glow.Remove();
                glowEntities.Remove(caller);
            }
        }

        return HookResult.Continue;
    }
}