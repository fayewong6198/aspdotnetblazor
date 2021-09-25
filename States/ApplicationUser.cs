namespace aspnetblazor.States
{
    public class ApplicationUser
    {
        private static string UserName {get;set;}
        private static string Email {get;set;}
        private static string Role {get;set;}
        private static string Avatar {get;set;}

        public static void setUserName(string username) {
            ApplicationUser.UserName = username;
        }
        public static void setAvatar(string avatar) {
            ApplicationUser.Avatar = avatar;
        }
        public static void setEmail(string email) {
            ApplicationUser.Email = email;
        }
        public static void setRole(string role) {
            ApplicationUser.Role = role;
        }


        public static string getUserName() {
            return ApplicationUser.UserName;
        }

        public static string getEmail() {
            return ApplicationUser.Email;
        }

        public static string getRole() {
            return ApplicationUser.Role;
        }

        public static string getAvatar() {
            return ApplicationUser.Avatar;
        }
         
    }
}