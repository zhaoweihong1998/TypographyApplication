using System.IO;
using Typography.OpenFont;
using Typography.TextLayout;
namespace FontLoader
{
    public class FontLoader
    {
        public static Typeface LoadFont(string path)
        {
            var file = new FileStream(path, FileMode.Open);
            var reader = new OpenFontReader();
            Typeface _ofTypeface = reader.Read(file);
            return _ofTypeface;
        }

        public static GlyphLayout GetGlyphLayout(Typeface typeface, char[] chars, bool gpos, bool gsub)
        {
            GlyphLayout layout = new GlyphLayout();
            layout.EnableGpos = gpos;
            layout.EnableGsub = gsub;
            layout.Typeface = typeface;
            layout.Layout(chars, 0, chars.Length);

            return layout;
        }


       /* static public void Main()
        {
            var typeface = LoadFont("./Fonts/Lobster-Regular.ttf");
            var layout = GetGlyphLayout(typeface, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),true,true);
            System.Console.WriteLine("done");
            foreach (var item in layout.GetUnscaledGlyphPlanIter())
            {
                System.Console.WriteLine(item.ToString());
            }
        }*/
    }
}
