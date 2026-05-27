
namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
        }

        // Sobrescreve o método CreateWindow para definir a página inicial do aplicativo
        protected override Window CreateWindow(IActivationState? activationState)
      {
            string? usuarioLogado = SecureStorage.Default.GetAsync("usuarioLogado").Result;
            Page paginaInicial;
            if (usuarioLogado == null)
            {
                paginaInicial = new Login(); // Se não houver usuário logado, a página inicial será a de login
            }
            else
            {
                paginaInicial = new Protegida(); // Se houver um usuário logado, a página inicial será a protegida
            }

            // paginaInicial vai receber a pagina de login como pagina inicial do aplicativo

            var Window = new Window(paginaInicial);

            Window.Width = 400;
            Window.Height = 700;

            return Window;

        }
    }
}