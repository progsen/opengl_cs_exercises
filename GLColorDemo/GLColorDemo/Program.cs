using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using GLColorDemo;

namespace GLColorDemo
{
    public static class Program
    {
        private static void Main()
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 600),
                Title = "LearnOpenTK - Transformations",

                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            using (MainWindow window = new MainWindow(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}

