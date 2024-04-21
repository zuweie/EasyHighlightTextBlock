# Easy Highlight TextBlock

我在开发一个 WPF 项目时，经常会使用 TextBlock 控件。当我想要高亮 TextBlock 中的字符串时，这是需要的代码：

```c#
// set the text background to yellow ~~
var yellowRun = new Run(text);
yellowRun.Background = new SolidColorBrush("yellow");
TextBlock.Inlines.add(yellowRun);

```

我是很怕麻烦的，我认为这种高亮方式不不简洁且不雅，像屎一样。于是我改造的 TextBlock，使得其在渲染其字符串时能识别字符串中的标签，并且根据不同的标签，实现不同的高亮效果如：





