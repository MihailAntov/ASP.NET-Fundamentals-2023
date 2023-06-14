namespace Musaca.Common
{
    public class ProductValidationConstants
    {
        public const string OnlyDigitsRegex = @"^[\d]{12}$";
        public const int ProductNameMaxLength = 50;
        public const int ProductNameMinLength = 5;
        public const double ProductMinPrice = 0.05;
    }
}
