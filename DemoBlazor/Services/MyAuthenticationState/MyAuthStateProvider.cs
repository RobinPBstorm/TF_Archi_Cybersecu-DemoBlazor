using DemoBlazor.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoBlazor.Services.MyAuthenticationState
{
	public class MyAuthStateProvider : AuthenticationStateProvider
	{
        private IStockageService _stockage { get; set; }
        public MyAuthStateProvider(IStockageService stockage)
		{
			_stockage = stockage;
		}
		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			string token = await _stockage.GetItem<string>("token");
			if (string.IsNullOrWhiteSpace(token))
			{

				ClaimsIdentity anonymous = new ClaimsIdentity();
				return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
			}

			JwtSecurityToken jwt = new JwtSecurityToken(token);
			ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");

			return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
		}

		public void NotifyUserChanged()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}
	}
	/*
	Le but de ce Provider est vérifier l'état de l'utilisateur et de pouvoir le propager dans toute l'application

	Il s'intégre dans le flux de la connection d'un utilisateur, voici on va le mettre en place:

	1) Créer un composant Login permettant de se connecter et récupérer le token dans l'api
	2) Créer le stateProvider qui vérifie l'existence du token et transmet l'utilisateur connecté à l'app
		Ce provider hérite AuthenticationStateProvider
			On devra implémenter la méthode abstraite GetAuthenticationStateAsync
			Ici, on a ajouté une méthode NotifyUserChanged pour propager le changement de User
	3) Modifier app.razor pour fournir l'état grâce à <CascadingStateProvider>
	4) Injecter le state provider en singleton dans le program.cs
	5) Ajouter builder.Services.AddAuthorizationCore(); dans le program.cs
	6) Ajouter dans les _imports de Microsoft.AspNetCore.Components.Authorization
		et de Microsoft.AspNetCore.Authorization
	7) Utilisation de @attribute [Authorize] pour limiter l'accès aux pages
			[Authorize(Roles = "...")] Si limité à un rôle particulier
	8) Utilisation de <AuthorizeView> + <Authorized> & <NotAuthorized> 
	=> Permet de cacher/afficher une partie de la vue/composant en fonction de l'état de connexion
 */
}
