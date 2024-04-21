
using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EasyHighlight
{
    public class EasyHighlightTextBlock : TextBlock
    {
        Dictionary<string, Func<string, string, Run>> M_decoraters = new Dictionary<string, Func<string, string, Run>>();

        public EasyHighlightTextBlock() : base()
        {
            setUpDefaultDecorates();
            DependencyPropertyDescriptor textDescriptor = DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(TextBlock));
            textDescriptor?.AddValueChanged(this, (sender, args) => UpdateText());
        }


        public void addDecorater(string tag, Func<string, string, Run> decorater)
        {
            M_decoraters.Add(tag, decorater);
        }


        private void UpdateText()
        {
            if (Text.Length == 0 || M_decoraters.Count == 0)
            {
                return;
            }

            string input = Text;
            string pattern = @"<(\w+)>([^<]+)</\1>";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            if (matches.Count == 0) 
                return;

            var originStyle = this.Style;
            
            Inlines.Clear();

            int startIndex = 0;
            
            foreach (Match match in matches)
            {
                if (match.Index != startIndex)
                {
                    // 有未被标签包裹的字符串在前面
                    Run unDecorateTextRun = new Run(Text.Substring(startIndex, match.Index - startIndex));
                    unDecorateTextRun.Style = originStyle;

                    Inlines.Add(unDecorateTextRun);
                }
                string TagName = match.Groups[1].Value;
                Func<string,string, Run> decorate = (Func<string, string, Run>)M_decoraters[TagName];
                Run decorateTextRun = null;

                if (decorate != null) { 

                    decorateTextRun = decorate(match.Groups[2].Value, match.Groups[1].Value);
                    if (decorateTextRun == null)
                    {
                        // 如果他妈的有傻逼返回空的 Run，则将原来的字符串弄回去。
                        decorateTextRun = new Run(match.Groups[2].Value);
                        decorateTextRun.Style = originStyle;
                    }

                } else {
                    
                    // 没找到相应的 decorate 的，直接把原来的 string 弄回去。
                    decorateTextRun = new Run(match.Groups[1].Value);
                    decorateTextRun.Style = originStyle;
                }
                Inlines.Add(decorateTextRun);

                startIndex = match.Index + match.Groups[0].Length;
            }

            // 还有一部分 未被包裹
            if (startIndex != Text.Length-1)
            {
                Run unDecorateRun = new Run(Text.Substring(startIndex, Text.Length - startIndex));
                unDecorateRun.Style = originStyle;
                Inlines.Add(unDecorateRun);
            }

        }


        private void setUpDefaultDecorates()
        {

            M_decoraters.Add("yellow", (string text, string tagName) => {
                var decorateTextRun = new Run(text);
                try
                {
                    // 尝试是否高亮颜色
                    Color color = (Color)ColorConverter.ConvertFromString(tagName);
                    decorateTextRun.Background = new SolidColorBrush(color);
                    return decorateTextRun;
                }
                catch (Exception ex)
                {
                    return null;
                }
                
            });

            M_decoraters.Add("red", (string text, string tagName) => {
                var decorateTextRun = new Run(text);
                try
                {
                    // 尝试是否高亮颜色
                    Color color = (Color)ColorConverter.ConvertFromString(tagName);
                    decorateTextRun.Background = new SolidColorBrush(color);
                    return decorateTextRun;
                }
                catch (Exception ex)
                {
                    return null;
                }
            });
            
            M_decoraters.Add("purple", (string text, string tagName) => {
                var decorateTextRun = new Run(text);
                try
                {
                    // 尝试是否高亮颜色
                    Color color = (Color)ColorConverter.ConvertFromString(tagName);
                    decorateTextRun.Background = new SolidColorBrush(color);
                }
                catch (Exception ex)
                {
                    return null;
                }
                return decorateTextRun;
            });

            M_decoraters.Add("green", (string text, string tagName) => {
                var decorateTextRun = new Run(text);
                try
                {
                    // 尝试是否高亮颜色
                    Color color = (Color)ColorConverter.ConvertFromString(tagName);
                    decorateTextRun.Background = new SolidColorBrush(color);
                }
                catch (Exception ex)
                {
                    return null;
                }
                return decorateTextRun;
            });

            M_decoraters.Add("gray", (string text, string tagName) =>
            {
                var decorateTextRun = new Run(text);
                try
                {
                    // 尝试是否高亮颜色
                    Color color = (Color)ColorConverter.ConvertFromString(tagName);
                    decorateTextRun.Background = new SolidColorBrush(color);
                }
                catch (Exception ex)
                {
                    return null;
                }
                return decorateTextRun;
            });

            M_decoraters.Add("b", (string text, string tagName) =>
            {
                var decorateTextRun = new Run(text);
                decorateTextRun.FontWeight = FontWeights.Bold;
                return decorateTextRun;
            });

            M_decoraters.Add("i", (string text, string tagName) => {
                var decorateTextRun = new Run(text);
                
                decorateTextRun.FontStyle = FontStyles.Italic;

                return decorateTextRun;
            });

            M_decoraters.Add("u", (string text, string tagName) => {
                var decorateTextRun = new Run(text);

                TextDecoration underline = new TextDecoration();

                underline.PenThicknessUnit = TextDecorationUnit.FontRecommended;
                underline.Pen = new Pen(Brushes.Black, 1.5);
                underline.Location = TextDecorationLocation.Underline;

                decorateTextRun.TextDecorations.Add(underline);
                return decorateTextRun;
            });

            M_decoraters.Add("del", (string text, string tagName) => {

                var decorateTextRun = new Run(text);

                TextDecoration strikethrough = new TextDecoration();
                strikethrough.PenThicknessUnit = TextDecorationUnit.FontRecommended;
                strikethrough.Pen = new Pen(Brushes.Black, 1.5);
                strikethrough.Location = TextDecorationLocation.Strikethrough;
                decorateTextRun.TextDecorations.Add(strikethrough);
                return decorateTextRun;
            });
        }
    }

}
