# Easy Highlight TextBlock

>A Easy Way to Highlight the Text using \<Tags\> like a html 

![autohighlight](https://raw.githubusercontent.com/zuweie/photobed/master/example2.gif)

## Introduce
**When working on a WPF project** , I often use the TextBlock. I feel **ball-ache** When I want to highlight the string in TextBlock !!
for example here's the code to Highlight Text by yellow :

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

EasyHighlightTextBlock.Text = text;
```

Then you'll get Highlight Text like this:
![EasyHighlightTextBlock](https://raw.githubusercontent.com/zuweie/photobed/master/QQ%E5%9B%BE%E7%89%8720240421153105.png)
It`s Cool !!!

## Install & Usage

- Search "**EasyHighlightTextBlock**" in Nuget and Install it
  ![EasyHightlightTExt](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240421201744.png?raw=true)
  
- SetUp EasyHighlightTextBlock in some xaml file like this.
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
        <ehl:EasyHighlightTextBlock x:Name="easyHText" Text="&lt;i>This&lt;/i> is &lt;gray>an&lt;/gray> &lt;yellow>Example&lt;/yellow> for a &lt;red>long&lt;/red> string to &lt;green>show&lt;/green> how the &lt;b>EsayHighlight&lt;/b> Text &lt;u>Block&lt;/u> &lt;purple>works!&lt;/purple> &lt;del>Hahah&lt;/del>" FontSize="20" Grid.Row="3" Margin="10,20"/>
    </Grid>
</Window>
```
  
>Notice: if you assign the string to Text attribute in xmal directly, then the chart '<' has to replace by "\&lt;"

## Supported Tags
>Here is a few Tags supported by My **Implement**：

|No|Tags|effects|
|--|--|--|
|1|\<yellow\>\<\\yellow\>|![yellow](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422080706.png?raw=true)|
|2|\<gree\>\<\\green\>|![gree](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422080748.png?raw=true)|
|3|\<red\>\<\\red\>|![red](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422080724.png?raw=true)|
|4|\<purple\><\\<purple\>|![purple](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422080816.png?raw=true)|
|5|\<gray\>\<\\gray\>|![gray](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422080645.png?raw=true)|
|5|\<i\>\<\\i\>|*Italics*|
|6|\<b\>\<\\b\>|**Blod**|
|7|\<u\>\<\\u\>| <ins>underline</ins> |
|8|\<del\>\<\\del\>|~~Strikethrough~~|

## Design Your Own Tags
If the above tags don't fit your needs, you can design your own. 
- Firstly Name your own tag, for example "red_del", means draw a red background and a strikethrough line to the string.
- Secondly do the Implement (how to draw) by the interface "addDecorater" of EasyHighlightTextBlock:

```C#
// implement the draw function in xxx.cs file.
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        easyHighlight.addDecorater("red_del", (string text, string tagName) => {
            // new a run
            Run redDelRun = new Run(text);
            // draw a striethroug line
            TextDecoration strikethrough = new TextDecoration();
            strikethrough.PenThicknessUnit = TextDecorationUnit.FontRecommended;
            strikethrough.Pen = new Pen(Brushes.Black, 1.5);
            strikethrough.Location = TextDecorationLocation.Strikethrough;
            redDelRun.TextDecorations.Add(strikethrough);

            // draw a red background
            Color color = (Color)ColorConverter.ConvertFromString("red");
            redDelRun.Background = Brushes.Red;
            // return the object RUN is IMPORTANT!!!
            return redDelRun;
        });

        // setup Text on xmal, or here !!!
        easyHText.Text = "<red_del>red_del</red_del> example."
        return;
    }
}

```

```Xaml
<Window x:Class="TestHL.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TestHL"
        xmlns:ehl="clr-namespace:EasyHighlight;assembly=EasyHighlightText"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="1200">
    <Grid>
        <TextBlock Name="M_test2" Text="&lt;red_del>red_del&lt;/red_del> example"  FontSize="20" Grid.Row="2" Margin="10,20"/>
        <ehl:EasyHighlightTextBlock x:Name="easyHightlight" Text="&lt;red_del>red_del&lt;/red_del> example" FontSize="20" Grid.Row="3" Margin="10,20"/>
    </Grid>
</Window>
```

It will be look like this:
![red_del](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240422100544.png?raw=true)

> Notice:
> 
> 1、The parameters of Function you implement to draw the highlight is:
> 
> **text** is the string wapped in your Tag.
> 
> **tagName** is the Tag.
> 
> 2、All the decoration is be coding on the objct call **"Run"**, So you must return this object, otherwise There will no **fucking things** would be happend.
>
> 3、For The **tagName** I just simply use The regular expression **\w+** to matche, So your tags must be **one or more alphanumeric characters (including letters, numbers, and underscores, [a-zA-Z0-9_])**. Don`t use any strange and special chart.
> 

## autoHgihlight
If you find all the highlighting methods too cumbersome, I've also prepared a more convenient interface for you: **autoHighlight**.
```C#
easyHighlightTextBlock.autoHighlight("tag", "target-str-you-want-to-hightlight");
```
- **tag** means the <tag> supported by the easyHighlightTextblock
- **target-str-you-want-to-hightlight** means you want to highlight in easyhgihlightTextblock

Example:
in xmal:
```C#
<Window x:Class="TestHL.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TestHL"
        xmlns:ehl="clr-namespace:EasyHighlight;assembly=EasyHighlightText"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="1200">
    <Grid Background="LightGray">
        <Grid.RowDefinitions>
            <RowDefinition Height="2.5*"/>
            <RowDefinition Height="2.5*"/>
            <RowDefinition Height="2.5*"/>
            <RowDefinition Height="2.5*"/>
        </Grid.RowDefinitions>

        <TextBox Name="M_TextBox" TextChanged="TextChangedEventHandler" FontSize="20" Grid.Row="0" Margin="10,20"/>
        <ehl:EasyHighlightTextBlock Name="easyHighlight1" FontSize="14" Text="Audrey Hepburn, an iconic figure of elegance and grace, captivated audiences with her timeless beauty and talent. Renowned for her iconic roles in films like Breakfast at Tiffany and Roman Holiday, she left an indelible mark on Hollywood. Beyond her acting prowess, Hepburn's humanitarian work and timeless style continue to inspire generations worldwide."  TextWrapping="Wrap" Grid.Row="1" Margin="10, 20"/>
        <TextBlock Name="M_test2" Text="&lt;red_del>red_del&lt;/red_del> example"  FontSize="20" Grid.Row="2" Margin="10,20"/>
        <ehl:EasyHighlightTextBlock x:Name="easyHightlight" Text="&lt;red_del>red_del&lt;/red_del> example" FontSize="20" Grid.Row="3" Margin="10,20"/>
    </Grid>
</Window>
```
in xmal.cs
```C#
 public partial class MainWindow : Window
 {
     public MainWindow()
     {
         InitializeComponent();
         easyHighlight1.addDecorater("yellow_underline", (string text, string tagName) => {
            Run redDelRun = new Run(text);

            TextDecoration del = new TextDecoration();
            del.PenThicknessUnit = TextDecorationUnit.FontRecommended;
            del.Pen = new Pen(Brushes.Black, 1.5);
            del.Location = TextDecorationLocation.Underline;
            redDelRun.TextDecorations.Add(del);

            redDelRun.Background = Brushes.Yellow;

            return redDelRun;
        });

easyHighlight.addDecorater("red_del", (string text, string tagName) => {
    Run redDelRun = new Run(text);

    TextDecoration del = new TextDecoration();
    del.PenThicknessUnit = TextDecorationUnit.FontRecommended;
    del.Pen = new Pen(Brushes.Black, 1.5);
    del.Location = TextDecorationLocation.Strikethrough;
    redDelRun.TextDecorations.Add(del);

    redDelRun.Background = Brushes.Red;

    return redDelRun;
});
         
         return;
     }

     private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
     {
         string target = M_TextBox.Text;
         easyHighlight1.autoHighlight("red_del", target);
         return;
     }

 }
```

look like:
![autohighlight](https://raw.githubusercontent.com/zuweie/photobed/master/example2.gif)

## last
If you neet to Hightligth the Text in TextbBlock too. **TRY** this SHIT !!! Any Problem contect me on email:51930595@qq.com

