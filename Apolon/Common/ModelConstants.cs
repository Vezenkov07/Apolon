namespace Apolon.Common;

public static class ModelConstants
{
    public static class Trainer
    {
        public const int FirstNameMinLength = 3;
        public const int FirstNameMaxLength = 50;
        public const string FirstNameRequiredErrorMessage = "First Name is required!";
        public const string FirstNameMinLengthErrorMessage = "First Name must be at least 3 characters long!";
        public const string FirstNameMaxLengthErrorMessage = "First Name must not be more than 50 characters long!";
        
        public const int LastNameMinLength = 3;
        public const int LastNameMaxLength = 50;
        public const string LastNameRequiredErrorMessage = "Last Name is required!";
        public const string LastNameMinLengthErrorMessage = "Last Name must be at least 3 characters long!";
        public const string LastNameMaxLengthErrorMessage = "Last Name must not be more than 50 characters long!";
        
        public const char AllowedGenderMale = 'M';
        public const char AllowedGenderFemale = 'F';
        public const string GenderRequiredErrorMessage = "Gender is required!";
        public const string AllowedGendersErrorMessage = "Gender must be M or F!";
        
        public const string PhoneNumberRegex = @"^(\+359|00359|0)(8[7-9]|9[8-9])\d{7}$";
        public const string PhoneNumberRequiredErrorMessage = "Phone Number is required!";
        public const string PhoneNumberAllowedErrorMessage = "Phone Number is not valid!";
        
        public const string EmailRequiredErrorMessage = "Email is required!";
        public const string EmailAllowedErrorMessage = "Email is not valid!";
        
        public const int ImageUrlMinLength = 5;
        public const int ImageUrlMaxLength = 100;
        public const string ImageRequiredErrorMessage = "Image is required!";
        
        public const int DescriptionMaxLength = 500;
        public const string DescriptionMaxLengthErrorMessage = "Description must not be more than 500 characters long!";
    }
    public static class Card
    {
        public const string CardTypeRequiredErrorMessage = "Card type is required!";
        public const string AllowedCardTypesErrorMessage = "Invalid card type selected!";

        public const string UserIdRequiredErrorMessage = "User ID is required!";

        public const string PriceRangeMinimum = "0.01";
        public const string PriceRangeMaximum = "10000.00";
        public const string PriceRequiredErrorMessage = "Price is required!";
        public const string PriceRangeErrorMessage = "Price must be between 0.01 and 10000.00!";
    }
    public static class Split
    {
        public const int SplitNameMinLength = 3;
        public const int SplitNameMaxLength = 100;
        public const string SplitNameRequiredErrorMessage = "Split name is required!";
        public const string SplitNameMinLengthErrorMessage = "Split name must be at least 3 characters long!";
        public const string SplitNameMaxLengthErrorMessage = "Split name must not exceed 100 characters!";

        public const string TargetedMusclesRequiredErrorMessage = "At least one targeted muscle group must be selected!";
    }
    public static class SupplementBrand
    {
        public const int BrandNameMinLength = 2;
        public const int BrandNameMaxLength = 100;
        public const string BrandNameRequiredErrorMessage = "Brand name is required!";
        public const string BrandNameMinLengthErrorMessage = "Brand name must be at least 2 characters long!";
        public const string BrandNameMaxLengthErrorMessage = "Brand name must not be more than 100 characters long!";

        public const string EmailRequiredErrorMessage = "Email is required!";
        public const string EmailAllowedErrorMessage = "Email is not valid!";

        public const string PhoneNumberRegex = @"^(\+359|00359|0)(8[7-9]|9[8-9])\d{7}$";
        public const string PhoneNumberRequiredErrorMessage = "Phone number is required!";
        public const string PhoneNumberAllowedErrorMessage = "Phone number is not valid!";

        public const int DescriptionMaxLength = 1000;
        public const string DescriptionMaxLengthErrorMessage = "Description must not be more than 1000 characters long!";
    }
    public static class SupplementCategory
    {
        public const string CategoryRequiredErrorMessage = "Category is required!";
        public const string AllowedCategoriesErrorMessage = "Invalid supplement category selected!";

        public const int DescriptionMaxLength = 500;
        public const string DescriptionMaxLengthErrorMessage = "Description must not exceed 500 characters!";
    }
    public static class Supplement
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 100;
        public const string NameRequiredErrorMessage = "Supplement name is required!";
        public const string NameMinLengthErrorMessage = "Supplement name must be at least 2 characters long!";
        public const string NameMaxLengthErrorMessage = "Supplement name must not exceed 100 characters!";

        public const string PriceRangeMinimum = "0.01";
        public const string PriceRangeMaximum = "10000.00";
        public const string PriceRequiredErrorMessage = "Price is required!";
        public const string PriceRangeErrorMessage = "Price must be between 0.01 and 10000.00!";

        public const string BrandIdRequiredErrorMessage = "Brand is required!";
        public const string CategoryIdRequiredErrorMessage = "Category is required!";

        public const int DescriptionMaxLength = 1000;
        public const string DescriptionMaxLengthErrorMessage = "Description must not exceed 1000 characters!";
    }
    public static class User
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;
        public const string FirstNameRequiredErrorMessage = "First name is required!";
        public const string FirstNameMinLengthErrorMessage = "First name must be at least 2 characters long!";
        public const string FirstNameMaxLengthErrorMessage = "First name must not exceed 50 characters!";

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 50;
        public const string LastNameRequiredErrorMessage = "Last name is required!";
        public const string LastNameMinLengthErrorMessage = "Last name must be at least 2 characters long!";
        public const string LastNameMaxLengthErrorMessage = "Last name must not exceed 50 characters!";

        public const string DateOfBirthRequiredErrorMessage = "Date of birth is required!";

        public const double WeightMin = 30.0;
        public const double WeightMax = 300.0;
        public const string WeightRequiredErrorMessage = "Weight is required!";
        public const string WeightRangeErrorMessage = "Weight must be between 30.0 kg and 300.0 kg!";

        public const double HeightMin = 100.0;
        public const double HeightMax = 250.0;
        public const string HeightRequiredErrorMessage = "Height is required!";
        public const string HeightRangeErrorMessage = "Height must be between 100.0 cm and 250.0 cm!";
        
        public const string PasswordRequiredErrorMessage = "Password is required!";
        public const string EmailRequiredErrorMessage = "Email is required!";
        public const string EmailInvalidErrorMessage = "Email is invalid!";
    }
    public static class Workout
    {
        public const string SplitIdRequiredErrorMessage = "Workout split is required!";
        public const string StartTimeRequiredErrorMessage = "Start time is required!";
        public const string EndTimeRequiredErrorMessage = "End time is required!";
    }

    public static class BookSession
    {
        public const string BookingDateRequiredErrorMessage = "Please select booking date!";
        
        public const string BookingTimeRequiredErrorMessage = "Please select booking time!";
        public const string BookingDatePastErrorMessage = "Booking date must be in the future!";
        public const string BookingTimeUnavailableErrorMessage = "That time slot is no longer available!";
        
        public const int NoteMaxLength = 500;
        public const int SessionDurationMinutes = 60;
        public const int OpeningHour = 6;
        public const int ClosingHour = 22;
    }
}