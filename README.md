# Easy Highlight TextBlock


**When developing a WPF project** , I often use the TextBlock control. When I want to highlight a string within a TextBlock, here's the code I need:

```c#
// set the text background to yellow ~~
var yellowRun = new Run(text);
yellowRun.Background = new SolidColorBrush("yellow");
TextBlock.Inlines.add(yellowRun);

```

I'm not a fan of the hassle, and I find this highlighting method not only inelegant but also cumbersome, like shit. So, I've modified the TextBlock to recognize tags within the string it renders, and based on different tags, achieve varying highlighting effects such as:

```C#
TextBlock.Text = "<i>This</i> is <gray>an</gray> <yellow>Example</yellow> for a <red>long</red> string to <green>show</green> how the <b>EsayHighlight</b> Text <u>Block</u> <purple>works!</purple> <del>Hahah</del>";
```





