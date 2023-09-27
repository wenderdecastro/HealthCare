namespace HealthClinic.Utils.Cryptography
{
    public class PasswordHashing
    {
        public static string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyHash (string FormPassword, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(FormPassword, HashedPassword);
        }
    }
}
