using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace IceArena.Web.Components.Layout
{
    partial class Header
    {

        private bool isAuthenticated;
        private string role = "";
        private bool isLoginOpen = false;
        private bool isInitialized = false;
        private bool showLogoutConfirm = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                AuthStateProvider.AuthenticationStateChanged += OnAuthenticationStateChanged;

                var authState = await AuthStateProvider.GetAuthenticationStateAsync();
                UpdateUserState(authState.User);

                isInitialized = true;
                StateHasChanged();
            }
        }

        private async void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;
            UpdateUserState(authState.User);
            StateHasChanged();
        }

        private void UpdateUserState(ClaimsPrincipal user)
        {
            isAuthenticated = user.Identity?.IsAuthenticated ?? false;
            role = user.FindFirst(ClaimTypes.Role)?.Value ?? "user";
        }

        private void ConfirmLogout()
        {
            showLogoutConfirm = true;
            StateHasChanged();
        }

        private void OpenLoginModal()
        {
            isLoginOpen = true;
        }

        public void Dispose()
        {
            AuthStateProvider.AuthenticationStateChanged -= OnAuthenticationStateChanged;
        }
    }
}
