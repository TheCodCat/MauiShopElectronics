using InputKit.Shared.Validations;

namespace MauiShopElectronics.Validations
{
    public class ValidationInt : IValidation
    {
        public string Message => "Введите число";

        public bool Validate(object value)
        {
            if(value is string text)
            {
                if (int.TryParse(text, out int result))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
