namespace Watchlist.Common
{
    public static class ValidationConstants
    {
        public static class User
        {
            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;
        }

        public static class Genre
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class Movie
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;
            public const decimal RatingMinValue = 0.00M;
            public const decimal RatingMaxValue = 10.00M;

        }
    }
}
