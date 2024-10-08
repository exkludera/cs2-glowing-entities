# cs2-glowing-entities

**a plugin to make entities glow, like `func_button`**

<br>

<details>
	<summary>showcase</summary>

https://github.com/user-attachments/assets/ad117529-e2e8-4a39-86af-b372ffc3e15b

</details>

<br>

## information:

### requirements

- [MetaMod](https://github.com/alliedmodders/metamod-source)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

<br>

> [!NOTE]
> inspired by [Glow buttons by Franc1sco](https://forums.alliedmods.net/showthread.php?p=2408999)

<img src="https://github.com/user-attachments/assets/53e486cc-8da4-45ab-bc6e-eb38145aba36" height="200px"> <br>

<br>

## example config

**RemoveOnPress** - Default: `false` (removes glow when entity is pressed) <br>
**RemoveOnDamage** - Default: `false` (removes glow when entity is damaged) <br>

**Color** - Default: `"255 255 255 128"` (RGBA) <br>
**Model** - Default: `"` (which model to use for glow outline, empty = the model from the target entity) <br>
**Range** - Default: `5000` (max glow range) <br>
**RangeMin** - Default: `0` (min glow range) <br>
**Team** - Default: `""` (which team can see the glow, T/CT or empty for both) <br>
**GlowOnAim** - Default `false` (only glows when aim is on the button, if false they will always glow) <br>

```json
{
  "RemoveOnPress": true,
  "RemoveOnDamage": true,
  "Entities": {
    "func_button": {
      "Color": "255 255 255 255",
      "Range": 5000,
      "Team": "CT",
      "GlowOnAim": true
    },
    "trigger_multiple": {
      "Color": "0 0 255 128",
      "Model": "models/props/de_dust/hr_dust/dust_soccerball/dust_soccer_ball001.vmdl",
      "Range": 1000,
      "GlowOnAim": false
    }
  }
}
```

<br> <a href='https://ko-fi.com/exkludera' target='_blank'><img src='https://cdn.ko-fi.com/cdn/kofi5.png' height='48px' alt='Buy Me a Coffee at ko-fi.com' /></a>
