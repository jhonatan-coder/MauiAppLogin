namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuario> listaUsuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "jose",
					Senha = "123"
				},
				new DadosUsuario()
				{
					Usuario = "maria",
					Senha = "321"
				}
			};

			DadosUsuario dadosDigitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

            //Usar biblioteca lINQ para fazer varredura de listas

            //Any - Retorna true se encontrar um elemento que satisfaça a condição, caso contrário, retorna false.
            if (listaUsuarios.Any(u => (dadosDigitados.Usuario == u.Usuario && dadosDigitados.Senha == u.Senha)))//FirstOrDefault - Retorna o primeiro elemento que satisfaz a condição ou um valor padrão se nenhum elemento for encontrado.
                                                                                                                 //var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => (dadosDigitados.Usuario == u.Usuario && dadosDigitados.Senha == u.Senha));
                                                                                                                 //if (usuarioEncontrado != null)
            {
				SecureStorage.Default.SetAsync("usuarioLogado", dadosDigitados.Usuario);//Armazenar o nome do usuário logado de forma segura
				App.Current.MainPage = new Protegida(); //Navegar para a página protegida
                DisplayAlertAsync("Mensagem","Login realizado com sucesso!", "Fechar");
			}
			else
			{
				throw new Exception("Usuario ou senha incorretos!");
            }
        }
		catch (Exception ex)
		{
			DisplayAlertAsync("Ops", ex.Message, "Fechar");
		}
    }
}