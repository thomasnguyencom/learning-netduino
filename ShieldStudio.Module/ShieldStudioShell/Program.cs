using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudioShell
{
    public class Program
    {
        public static void Main()
        {
            var view = new ShieldStudioView();
            view.WritePhrase(new DisplayPanel[] {
                    new DisplayPanel('S', 'h', 'i', 'e'),
                    new DisplayPanel('l', 'd', 'S', 't'),
                    new DisplayPanel('u', 'd', 'i', 'o'),
                    new DisplayPanel('.', 'c', 'o', 'm')
                });
        }

    }
}
