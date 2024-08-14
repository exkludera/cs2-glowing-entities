# cs2-glowing-buttons

**Glowing Buttons plugin makes func_button glow, mostly for zombie escape**

<br>

<details>
	<summary>showcase</summary>
	<img src="https://cdn.discordapp.com/attachments/1039451649254629406/1273072243076763668/20240814021413_1.jpg?ex=66bd486b&is=66bbf6eb&hm=9a8e741d24cec0620c4db0b772d488e552336b9a07512004d56c8a5546b3218c&" width="500">
</details>

<br>

## information:

### requirements

- [MetaMod](https://cs2.poggu.me/metamod/installation)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

<br>

> [!NOTE]
> inspired by [Glow buttons by Franc1sco](https://forums.alliedmods.net/showthread.php?p=2408999)

<img src="https://media.discordapp.net/attachments/1051988905320255509/1146537451750432778/ezgif.com-video-to-gif_2.gif?ex=66a359f6&is=66a20876&hm=768e346857f44792cf5b2917fe55b525522029ecccac95bb765b881baa6660d7&" width="250">

<br>

<a href='https://ko-fi.com/G2G2Y3Z9R' target='_blank'><img style='border:0px; height:75px;' src='https://storage.ko-fi.com/cdn/brandasset/kofi_s_tag_dark.png?_gl=1*6vhavf*_gcl_au*MTIwNjcwMzM4OC4xNzE1NzA0NjM5*_ga*NjE5MjYyMjkzLjE3MTU3MDQ2MTM.*_ga_M13FZ7VQ2C*MTcyMjIwMDA2NS4xNy4xLjE3MjIyMDA0MDUuNjAuMC4w' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a> <br>

## example config

**Color** - Default: `"255 255 255 128"` (RGBA) <br>
**Model** - Default: `"models/props/de_dust/hr_dust/dust_soccerball/dust_soccer_ball001.vmdl` (which model to use for glow outline) <br>
**Range** - Default: `5000` (max glow range) <br>
**RangeMin** - Default: `0` (min glow range) <br>
**Team** - Default: `""` (which team can see the glow, T/CT or empty for both) <br>
**GlowOnAim** - Default `false` (only glows when aim is on the button, if false they will always glow) <br>
**RemoveOnPress** - Default: `true` (removes glow when button is pressed) <br>

```json
{
  "Color": "255 255 255 128",
  "Model": "models/props/de_dust/hr_dust/dust_soccerball/dust_soccer_ball001.vmdl",
  "Range": 5000,
  "RangeMin": 0,
  "Team": "",
  "GlowOnAim": false,
  "RemoveOnPress": true
}
```