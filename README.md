# Easy Highlight TextBlock
## Introduce
**When developing a WPF project** , I often use the TextBlock. I feel **ball-ache** When I want to highlight the string of TextBlock !!
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

EasyHighlightTextBlock.Text = string;
```

Then you'll get Highlight Text like this:
![EasyHighlightTextBlock](https://raw.githubusercontent.com/zuweie/photobed/master/QQ%E5%9B%BE%E7%89%8720240421153105.png)
It`s Cool !!!

## Install & Usage

- Search "**EasyHighlightTextBlock**" in Nuget and Install it
  ![EasyHightlightTExt](https://github.com/zuweie/photobed/blob/master/QQ%E5%9B%BE%E7%89%8720240421201744.png?raw=true)
  
- SetUp EasyHighlightTextBlock in some xaml file
```xml
```
  

>if you assign the string to Text attribute directly in xmal, then the chart '<' has to replace by "\&lt;"







