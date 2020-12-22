# ✨ Magic Tooltips ✨

A PowerShell module to display contextual information about the command you're currently entering.

![Magic Tooltips Demo](/media/demo.gif)

Pairs nicely with custom prompts, such as [oh-my-posh3](https://github.com/JanDeDobbeleer/oh-my-posh3)!
![Magic Tooltips with oh-my-posh3](/media/oh-my-posh3.png)


Supported Providers:
- Kubernetes - Shows the current kubernetes context
- Azure - Shows the name of the current azure subscription
- (more to come)

## Prerequisites
- Powershell 7+
- CLI tools installed and in your path for one or more of the supported providers
- (optional) A [Nerd Font](https://www.nerdfonts.com/) installed and selected as your terminal's font

## Installation

You can install and import Magic Tooltips from the PowerShell Gallery:

```pwsh
Install-Module MagicTooltips
Import-Module MagicTooltips
```

To make the module auto-load, add the Import-Module line to your [PowerShell profile](#powershell-profile).

## Configuration

Configuration is done by setting global variables in your [PowerShell profile](#powershell-profile).

### Commands
To configure when different tooltips are shown, edit the command variables with a comma separted list of commands
```pwsh
$global:MagicTooltips_KubernetesCommands = "kubectl,helm,kubens,kubectx,oc,istioctl,kogito,k9s,helmlist"
$global:MagicTooltips_AzureCommands = "az,terraform,pulumi,terragrunt"
```

### Colors
To configure the colors, use hex colors in the following variables
```pwsh
$global:MagicTooltips_KubernetesFgColor="#AE5FD6"
$global:MagicTooltips_KubernetesBgColor="#000000"
$global:MagicTooltips_AzureFgColor="#3A96DD"
$global:MagicTooltips_AzureBgColor="#000000"
```

### Templates
MagicTooltips can be drawn with a simple template language, provided by the following variables:
```pwsh
$global:MagicTooltips_KubernetesTemplate = "`u{fd31} {value}"
$global:MagicTooltips_AzureTemplate = "`u{fd03} {value}"
```

The string you provide here will be printed to the host. The string `{value}` will be replaced with the value returned by the provider (kubernetes cluster name, for example).

If you would like to use icons, make sure you have a [Nerd Font](https://www.nerdfonts.com/) selected as your terminal's font. Write icons using the syntax `` `u{fd03}`` where `fd03` is the hex code for the unicode character you wish to print. You can find these hex codes on the [Nerd Font Cheat Sheet](https://www.nerdfonts.com/cheat-sheet).

### Placement
To configure placement, set the following variables
```pwsh
$global:MagicTooltips_HorizontalAlignment = "right"
$global:MagicTooltips_HorizontalOffset = 0
$global:MagicTooltips_VerticalOffset = -1
```

- `HorizontalAlignment` default "right". Possible values are "left" or "right"
- `HorizontalOffset` default 0. specify the number of columns to offset from the left or right edge of the terminal
- `VerticalOffset` default 0. specify the number of rows to offset from the cursor position. Negative values will cause printing 
to appear above the cursor row, while positive values will print below the cursor row.

### Debug
To enable debug logs, set the following variable.
```pwsh
$global:MagicTooltips_Debug="true"
```
 The log file is called `magictooltips.log` and is written to the module directory, which can be found using
```pwsh
(Get-Module MagicTooltips).ModuleBase
```


## PowerShell Profile

The path to your PowerShell profile is stored by PowerShell in the variable `$profile`. The following commands will launch a text editor with your profile:

Visual Studio Code
```pwsh
code $profile
```

Notepad
```pwsh
notepad $profile
```

Once you have made changes to your profile, you can reload your profile in PowerShell:
```pwsh
.$profile
```

## Roadmap
- More Providers
    - AWS
    - Gcloud
- Caching for performance improvements

## Acknowledgments
- [Powerlevel10k](https://github.com/romkatv/powerlevel10k)
- [oh-my-posh3](https://github.com/JanDeDobbeleer/oh-my-posh3)
- [Nerd Fonts](https://www.nerdfonts.com/)
