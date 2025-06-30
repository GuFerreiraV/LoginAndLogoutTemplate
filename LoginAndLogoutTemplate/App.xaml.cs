namespace LoginAndLogoutTemplate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            string? usuario_logado = null;

            Task.Run(async () =>
            {
                // obtém usuari logado do SecureStorage
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if(usuario_logado != null)
                {
                    // Se o usuário estiver logado, redireciona para a página protegida
                    MainPage = new Protegida();
                }
                else
                {
                    // Caso contrário, redireciona para a página de login
                    MainPage = new Login();
                }
            });

            MainPage = new Login();

        }

        // Redimensionamento de tela
        protected override Window CreateWindow(IActivationState ActivationState)
        {
            var window = base.CreateWindow(ActivationState);

            window.Width = 400;
            window.Height = 700;
            return window;
        }
    }
}
