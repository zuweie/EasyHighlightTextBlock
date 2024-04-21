# Easy Highlight TextBlock
## Introduce
**When developing a WPF project** , I often use the TextBlock control. I feel **ball-ache** When I want to highlight a string within a TextBlock! 
for example here's the code to Highlight Text within yellow :

```c#
// set the text background to yellow ~~
var yellowRun = new Run(text);
yellowRun.Background = new SolidColorBrush("yellow");
TextBlock.Inlines.add(yellowRun);

```

I find this highlighting method not only **ungracefulness** but also **cumbersome**, like shit. So, I've modified the TextBlock to recognize tags within the string it renders, and based on different tags, achieve varying highlighting effects, Highlight the Text will be as simple as you do in html, such as Text :

```C#
string text
  = "<i>This</i> is <gray>an</gray> <yellow>Example</yellow> for a <red>long</red>
     string to <green>show</green> how the <b>EsayHighlight</b> Text <u>Block</u> <purple>works!</purple> <del>Hahah</del>";

EasyHighlightTextBlock.Text = string;
```

Then you'll get Highlight Text like this:
![EasyHighlightTextBlock](https://raw.githubusercontent.com/zuweie/photobed/master/QQ%E5%9B%BE%E7%89%8720240421153105.png)
It`s Cool !!!

## Install & Usage

- Search "**EasyHighlightTextBlock**" in Nuget and Install it
  ![EasyHightlightTExt](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240421201744.png?raw=true)
  
- SetUp EasyHighlightTextBlock in any xaml file
  ```xml
  <Window x:Class="TestHL.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TestHL"
        <!-- define a namespae for EasyHighlightTextBlock in xaml file -->
        xmlns:ehl="clr-namespace:EasyHighlight;assembly=EasyHighlightText"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="1200">
    <Grid>
        <ehl:EasyHighlightTextBlock x:Name="M_EText1" Text="&lt;yello>yellow&lt;/yellow> example" FontSize="20" Grid.Row="3" Margin="10,20"/>
    </Grid>
</Window>
  ```






