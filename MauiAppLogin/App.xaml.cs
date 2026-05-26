using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Não use mais: MainPage = new AppShell();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Inicialize a janela com a Page raiz aqui
            var window = new Window(new AppShell());

            window.Width = 400;
            window.Height = 700;

            return window;
        }
    }
}