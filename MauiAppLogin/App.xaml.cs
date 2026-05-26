using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Page paginaInicial;

            string? usuarioLogado = SecureStorage.Default.GetAsync("usuarioLogado").Result;
            if (usuarioLogado == null)
            {
                paginaInicial = new Login();
            }
            else
            {
                paginaInicial = new Protegida();
            }
            // Inicialize a janela com a Page raiz aqui
            var window = new Window(paginaInicial);


            window.Width = 400;
            window.Height = 700;

            return window;
        }
    }
}