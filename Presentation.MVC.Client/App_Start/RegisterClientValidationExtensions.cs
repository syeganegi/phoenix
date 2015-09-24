using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Phoenix.PhoenixApp.Presentation.MVC.Client.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}