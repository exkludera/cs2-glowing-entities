<div align="center">
  <img width="50" height="50" alt="cssharp" src="https://github.com/user-attachments/assets/3393573f-29be-46e1-bc30-fafaec573456" />
	<h3><strong>Glowing Entities</strong></h3>
	<h4>a plugin to make entities glow, like `func_button`</h4>
	<h2>
		<img src="https://img.shields.io/github/downloads/exkludera-cssharp/glowing-entities/total" alt="Downloads">
		<img src="https://img.shields.io/github/stars/exkludera-cssharp/glowing-entities?style=flat&logo=github" alt="Stars">
		<img src="https://img.shields.io/github/forks/exkludera-cssharp/glowing-entities?style=flat&logo=github" alt="Forks">
		<img src="https://img.shields.io/github/license/exkludera-cssharp/glowing-entities" alt="License">
	</h2>
	<!--<a href="https://discord.gg" target="_blank"><img src="https://img.shields.io/badge/Discord%20Server-7289da?style=for-the-badge&logo=discord&logoColor=white" /></a> <br>-->
	<a href="https://ko-fi.com/exkludera" target="_blank"><img src="https://img.shields.io/badge/KoFi-af00bf?style=for-the-badge&logo=kofi&logoColor=white" alt="Buy Me a Coffee at ko-fi.com" /></a>
	<a href="https://paypal.com/donate/?hosted_button_id=6AWPNVF5TLUC8" target="_blank"><img src="https://img.shields.io/badge/PayPal-0095ff?style=for-the-badge&logo=paypal&logoColor=white" alt="PayPal"  /></a>
	<a href="https://github.com/sponsors/exkludera" target="_blank"><img src="https://img.shields.io/badge/Sponsor-696969?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Sponsor" /></a>
</div>

> [!NOTE]
> inspired by [Glow buttons by Franc1sco](https://forums.alliedmods.net/showthread.php?p=2408999)

<img src="https://github.com/user-attachments/assets/53e486cc-8da4-45ab-bc6e-eb38145aba36" height="200px"> <br>

## Requirements
- [MetaMod](https://github.com/alliedmodders/metamod-source)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

## Showcase
<details>
	<summary>content</summary>

https://github.com/user-attachments/assets/ad117529-e2e8-4a39-86af-b372ffc3e15b

</details>

## Config

<details>
<summary>GlowingEntities.json</summary>

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
</details>
