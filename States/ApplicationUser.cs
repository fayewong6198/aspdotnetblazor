namespace aspnetblazor.States
{
    public class ApplicationUser
    {
        private static string UserName {get;set;}
        private static string Email {get;set;}
        private static string Role {get;set;}
        private static string Avatar {get;set;}
        private static bool IsAuthenticated{get;set;}

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
        public static void setLogin() {
            ApplicationUser.IsAuthenticated = true;
        }
        public static void setLogout() {
            ApplicationUser.IsAuthenticated = false;
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

        public static bool IsLogin() {
            return ApplicationUser.IsAuthenticated;
        }
         
    }
}