namespace DiplomContentSystem.Dto.Login
{
    public class LoginDto
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Should this user be remembered next time attempting to view secured pages
        /// </summary>
        public bool RememberMe { get; set; }
    }
}